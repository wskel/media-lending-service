import { Injectable } from '@angular/core';
import { HttpErrorResponse, HttpEvent, HttpHandler, HttpInterceptor, HttpRequest } from "@angular/common/http";
import { Router } from "@angular/router";
import { BehaviorSubject, catchError, filter, from, Observable, switchMap, take, throwError } from "rxjs";
import { TokenService } from "../services/token.service";
import { REFRESH_PATH } from "../services/api.service";
import { AuthService } from "../services/auth.service";
import { LoggingService } from "../services/logging.service";
import { PATHS } from "../app-routing.module";

@Injectable({
  providedIn: 'root'
})
export class AuthInterceptor implements HttpInterceptor {
  // scenarios where the app must refresh the access token
  // more frequently than every 2 minutes are not supported
  private readonly REFRESH_MINIMUM_IN_MILLI = 2 * 60 * 1000;
  private readonly host = window.location.host;

  private isRefreshing = false;
  private refreshTokenSubject: BehaviorSubject<string | null> = new BehaviorSubject<string | null>(null);
  private lastRefresh: number = 0;

  public constructor(
    private logger: LoggingService,
    private router: Router,
    private tokenService: TokenService,
    private authService: AuthService) {
  }

  public intercept(req: HttpRequest<any>, next: HttpHandler): Observable<HttpEvent<any>> {
    const requestUrl = req.url;
    if (this.isAbsoluteUrl(requestUrl)) {
      const requestHost = new URL(requestUrl).host;
      this.logger.debug('Absolute URL detected, checking host');

      if (requestHost !== this.host) {
        this.logger.info('External host detected, skipping authentication:', requestHost);
        return next.handle(req);
      }
      // skip authentication as a fallback (e.g. exotic scheme)
    } else if (!this.isRelativeUrl(requestUrl)) {
      this.logger.warn('URL type (relative or absolute) could not be determined, skipping authentication');
      return next.handle(req);
    }

    const accessToken = this.tokenService.getAccessToken();
    this.refreshTokenSubject.next(this.tokenService.getRefreshToken());
    let authenticatedRequest = this.buildAuthenticated(req, accessToken)

    return next.handle(authenticatedRequest).pipe(
      catchError((error: HttpErrorResponse) => {
        if (error.status === 401
          // prevent infinite recursion in the edge case where the refresh endpoint returns a 401
          && req.url !== REFRESH_PATH
          // prevent erroneous 401s on the login screen from needlessly attempting to refresh
          && this.refreshTokenSubject.value !== null
        ) {
          return this.handle401(req, next);
        }
        return throwError(() => error);
      })
    );
  }

  private isAbsoluteUrl = (url: string) =>
    /^([a-z0-9]*:|.{0})\/\/.*$/.test(url);

  private isRelativeUrl = (url: string) =>
    /^[^\/]+\/[^\/].*$|^\/[^\/].*$/.test(url);

  private buildAuthenticated(
    req: HttpRequest<any>,
    accessToken: string | null
  ): HttpRequest<any> {
    let authenticatedRequest = req;

    if (accessToken) {
      authenticatedRequest = req.clone({
        setHeaders: {
          Authorization: `Bearer ${accessToken}`
        }
      });
    }
    return authenticatedRequest;
  }

  private handle401(req: HttpRequest<any>, next: HttpHandler): Observable<HttpEvent<any>> {
    let elapsed = (Date.now() - this.lastRefresh);

    // return immediately if token is null and last refresh was less than x minutes ago
    if (this.refreshTokenSubject.value === null && elapsed < this.REFRESH_MINIMUM_IN_MILLI) {
      return throwError(() => new Error(`Access token refresh failed ${elapsed}ms ago`));
    }

    if (!this.isRefreshing) {
      this.isRefreshing = true;
      this.refreshTokenSubject.next(null);

      return from(this.tokenService.getAccessTokenRefreshed()).pipe(
        catchError((error) => {
          this.refreshTokenSubject.complete();
          this.isRefreshing = false;
          return throwError(() => error);
        }),
        switchMap((accessToken: string | null) => {
          if (accessToken) {
            this.refreshTokenSubject.next(accessToken);
            this.isRefreshing = false;
            return next.handle(this.buildAuthenticated(req, accessToken));
          } else {
            this.refreshTokenSubject.complete();
            this.isRefreshing = false;
            this.doLogout();
            return throwError(() => new Error('accessToken refresh failed: accessToken was null'));
          }
        })
      );
    } else {
      return this.refreshTokenSubject.pipe(
        filter(token => token !== null),
        take(1),
        switchMap(token => {
          return next.handle(this.buildAuthenticated(req, token));
        })
      );
    }
  }

  private doLogout() {
    this.authService.logout()
    this.router.navigate([PATHS.LOGIN]);
  }
}
