import { CanActivateFn, Router } from '@angular/router';
import { AuthService } from "../services/auth.service";
import { inject } from "@angular/core";
import { PATHS } from "../app-routing.module";
import { LoggingService } from "../services/logging.service";

export const authGuard: CanActivateFn = (_, state) => {
  const logger = inject(LoggingService);
  const authService = inject(AuthService);
  const router = inject(Router);
  const canActivate = authService.canActivate();

  if (!canActivate) {
    logger.debug(`Redirecting to ${PATHS.LOGIN}`);
    router.navigate([PATHS.LOGIN], {queryParams: {returnUrl: state.url}})
      .then(navigationResult => {
        if (navigationResult) {
          logger.debug(`Navigation to ${PATHS.LOGIN} success`);
        } else {
          logger.error(`Navigation to ${PATHS.LOGIN} failure`);
        }
      })
      .catch(error => {
        logger.error('Error navigating to ${PATHS.LOGIN}', error);
      });
  }

  return canActivate;
};
