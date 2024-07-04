import { Component } from '@angular/core';
import { LoggingService } from '../../services/logging.service';
import { UserRoleDto } from "../../models/user-role.dto";
import { AuthService } from "../../services/auth.service";
import { Router } from "@angular/router";
import { PATHS } from "../../app-routing.module";

@Component({
  selector: 'app-registration',
  templateUrl: './registration.component.html',
  styleUrl: './registration.component.css'
})
export class RegistrationComponent {
  protected email: string = '';
  protected password: string = '';
  protected preferredName: string | null = null;
  protected role: UserRoleDto = UserRoleDto.Customer;

  protected roleOptions = [
    {value: UserRoleDto.Customer, viewValue: 'Customer'},
    {value: UserRoleDto.Librarian, viewValue: 'Librarian'}
  ];

  public constructor(private logger: LoggingService, private authService: AuthService, private router: Router) {
  }

  public onSubmit() {
    this.authService.registerUser(this.email, this.password, this.preferredName, this.role)
      .subscribe({
        next: (response) => {
          this.logger.debug('Registration success, attempting authentication...', response);
          this.authService.authenticateUser(this.email, this.password)
            .subscribe({
              next: (response) => {
                this.logger.debug('Authentication success, redirecting...');
                this.router.navigate([PATHS.ROOT]);
              },
              error: (error) => {
                this.logger.error('Authentication error', error);
              },
              complete: () => {
                this.logger.debug('Authentication complete');
              }
            });
        },
        error: (error) => {
          this.logger.error('Registration error', error);
        },
        complete: () => {
          this.logger.debug('Registration complete');
        }
      });
  }
}
