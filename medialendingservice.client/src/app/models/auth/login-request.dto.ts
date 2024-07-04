export interface LoginRequestDto {
  email?: string;
  password?: string;
  twoFactorCode?: string;
  twoFactorRecoveryCode?: string;
}
