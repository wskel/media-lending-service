import { Component } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import { AuthService } from '../../services/auth.service';
import { LoggingService } from '../../services/logging.service';
import { NAV_PATHS } from "../../app-routing.module";
import { AppRouter } from "../../utils/app-router";

@Component({
  selector: 'app-login',
  templateUrl: './login.component.html',
  styleUrls: ['./login.component.scss']
})
export class LoginComponent {
  protected email: string = '';
  protected password: string = '';
  protected returnUrl: string;

  public constructor(
    private logger: LoggingService,
    private authService: AuthService,
    private router: AppRouter,
    private route: ActivatedRoute) {
    this.returnUrl = this.route.snapshot.queryParams['returnUrl'] || NAV_PATHS.ROOT;
  }

  public onSubmit() {
    this.authService.authenticateUser(this.email, this.password).subscribe({
      next: (response) => {
        this.logger.debug('Login success, redirecting...', response);
        this.router.navigate([this.returnUrl]);
      },
      error: (error) => {
        this.logger.error('Login error', error);
      },
      complete: () => {
        this.logger.debug('Login complete');
      }
    });
  }

  protected readonly NAV_PATHS = NAV_PATHS;
}
