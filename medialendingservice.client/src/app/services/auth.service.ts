import { Injectable } from '@angular/core';
import { LoginRequestDto } from "../models/auth/login-request.dto";
import { LoggingService } from "./logging.service";
import { TokenService } from "./token.service";
import { ApiService } from "./api.service";
import { RegisterRequestDto } from "../models/register-request.dto";
import { BehaviorSubject, Observable, tap } from "rxjs";
import { UserRoleDto } from "../models/user-role.dto";

@Injectable({
  providedIn: 'root'
})
export class AuthService {
  private isLoggedInSubject = new BehaviorSubject<boolean>(this.canActivate());
  public isLoggedIn$ = this.isLoggedInSubject.asObservable();

  public constructor(
    private logger: LoggingService,
    private apiService: ApiService,
    private tokenService: TokenService) {
  }

  public canActivate(): boolean {
    return this.tokenService.hasValidAccessToken() || !!this.tokenService.getRefreshToken();
  }

  public registerUser(
    email: string,
    password: string,
    preferredName: string | null,
    role: UserRoleDto
  ): Observable<void> {
    const registerRequest: RegisterRequestDto = {
      email,
      password,
      preferredName,
      role
    };
    return this.apiService.register(registerRequest).pipe(
      tap({
        next: () => this.logger.debug('Registration success'),
        error: (error) => this.logger.error('Registration error', error),
        complete: () => this.logger.debug('Registration complete')
      })
    );
  }

  public authenticateUser(email: string, password: string) {
    const loginRequest: LoginRequestDto = {
      email,
      password
    };
    return this.apiService.login(loginRequest).pipe(
      tap({
        next: (response) => {
          this.tokenService.setTokens(response);
          this.isLoggedInSubject.next(true);
          this.logger.debug('Login success', response);
        },
        error: (error) => this.logger.error('Login error', error),
        complete: () => this.logger.debug('Login complete')
      })
    );
  }

  public logout(): void {
    this.tokenService.clear();
    this.isLoggedInSubject.next(false);
    this.logger.debug('Logged out');
  }
}
