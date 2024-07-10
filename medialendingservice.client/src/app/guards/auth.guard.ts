import { CanActivateFn } from '@angular/router';
import { AuthService } from "../services/auth.service";
import { inject } from "@angular/core";
import { NAV_PATHS } from "../app-routing.module";
import { LoggingService } from "../services/logging.service";
import { AppRouter } from "../utils/app-router";

export const authGuard: CanActivateFn = (_, state) => {
  const logger = inject(LoggingService);
  const authService = inject(AuthService);
  const router = inject(AppRouter);
  const canActivate = authService.canActivate();

  if (!canActivate) {
    logger.debug(`Redirecting to ${NAV_PATHS.LOGIN}`);
    router.navigate([NAV_PATHS.LOGIN], {queryParams: {returnUrl: state.url}});
  }

  return canActivate;
};
