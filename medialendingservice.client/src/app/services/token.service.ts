import { Injectable } from '@angular/core';
import { ApiService } from "./api.service";
import { RefreshRequestDto } from "../models/auth/refresh-request.dto";
import { firstValueFrom } from "rxjs";
import { AccessTokenResponseDto } from "../models/auth/access-token-response.dto";
import { LoggingService } from "./logging.service";

@Injectable({
  providedIn: 'root'
})
export class TokenService {
  private readonly ACCESS_TOKEN_KEY = 'accessToken';
  private readonly REFRESH_TOKEN_KEY = 'refreshToken';
  private readonly ACCESS_TOKEN_EXPIRATION = 'accessTokenExpiration';

  public constructor(private logger: LoggingService, private apiService: ApiService) {
  }

  public setTokens(response: AccessTokenResponseDto | null): void {
    if (response) {
      const accessToken = response.accessToken
      if (accessToken) {
        localStorage.setItem(this.ACCESS_TOKEN_KEY, accessToken);
      }

      const expiresIn = response.expiresIn;
      if (expiresIn) {
        const expiration = Date.now() + expiresIn;
        localStorage.setItem(this.ACCESS_TOKEN_EXPIRATION, expiration.toString());
      }

      const refreshToken = response.refreshToken
      if (refreshToken) {
        localStorage.setItem(this.REFRESH_TOKEN_KEY, refreshToken);
      }
    }
  }

  public getAccessToken(): string | null {
    return localStorage.getItem(this.ACCESS_TOKEN_KEY);
  }

  public async getAccessTokenRefreshed(): Promise<string | null> {
    const refreshToken = this.getRefreshToken();

    // no point in trying to refresh without a valid refresh token
    if (!refreshToken) {
      return null;
    }

    try {
      const refreshRequest: RefreshRequestDto = {refreshToken};
      const response = await firstValueFrom(this.apiService.refresh(refreshRequest));
      this.setTokens(response)

      return response?.accessToken ?? null;
    } catch (error) {
      this.logger.error("Error refreshing access token", error);
      return null;
    }
  }

  public getRefreshToken(): string | null {
    return localStorage.getItem(this.REFRESH_TOKEN_KEY);
  }

  public hasValidAccessToken(): boolean {
    const expiration = this.getAccessTokenExpiration();
    if (!expiration) {
      return false;
    }
    return new Date().getTime() < expiration;
  }

  private getAccessTokenExpiration(): number | null {
    const expiry = localStorage.getItem(this.ACCESS_TOKEN_EXPIRATION);
    return expiry ? parseInt(expiry, 10) : null;
  }

  public clear(): void {
    localStorage.removeItem(this.ACCESS_TOKEN_KEY);
    localStorage.removeItem(this.REFRESH_TOKEN_KEY);
    localStorage.removeItem(this.ACCESS_TOKEN_EXPIRATION);
  }
}
