import { Injectable } from '@angular/core';
import { HttpClient, HttpErrorResponse } from '@angular/common/http';
import { Observable, throwError } from 'rxjs';
import { catchError } from 'rxjs/operators';
import { LoggingService } from './logging.service';
import { LoginRequestDto } from "../models/auth/login-request.dto";
import { AccessTokenResponseDto } from "../models/auth/access-token-response.dto";
import { RefreshRequestDto } from "../models/auth/refresh-request.dto";
import { RegisterRequestDto } from "../models/register-request.dto";

export const REFRESH_PATH = "/api/v0/refresh";

// noinspection JSUnusedGlobalSymbols
@Injectable({
  providedIn: 'root'
})
export class ApiService {

  public constructor(private logger: LoggingService, private http: HttpClient) {
  }

  private handleError(error: HttpErrorResponse) {
    this.logger.error('Request error', error);
    return throwError(() => error);
  }

  public login(request: LoginRequestDto): Observable<AccessTokenResponseDto | null> {
    return this.http.post<AccessTokenResponseDto>("/api/v0/login", request).pipe(
      catchError(this.handleError.bind(this))
    );
  }

  public register(request: RegisterRequestDto): Observable<void> {
    return this.http.post<void>("/api/v0/register", request).pipe(
      catchError(this.handleError.bind(this))
    );
  }

  public refresh(request: RefreshRequestDto): Observable<AccessTokenResponseDto | null> {
    return this.http.post<AccessTokenResponseDto>(REFRESH_PATH, request).pipe(
      catchError(this.handleError.bind(this))
    );
  }
}
