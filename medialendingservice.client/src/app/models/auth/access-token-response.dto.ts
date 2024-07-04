export interface AccessTokenResponseDto {
  tokenType?: string;
  accessToken?: string;
  expiresIn: number;
  refreshToken?: string;
}
