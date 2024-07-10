import { Component } from '@angular/core';
import { LoggingService } from '../../services/logging.service';
import { UserRoleDto } from "../../models/user-role.dto";
import { AuthService } from "../../services/auth.service";
import { ActivatedRoute } from "@angular/router";
import { NAV_PATHS } from "../../app-routing.module";
import { AppRouter } from "../../utils/app-router";
import { AbstractControl, FormControl, FormGroup, ValidationErrors, ValidatorFn, Validators } from "@angular/forms";

@Component({
  selector: 'app-registration',
  templateUrl: './registration.component.html',
  styleUrl: './registration.component.scss'
})
export class RegistrationComponent {
  protected returnUrl: string;
  protected isLoading = false;
  protected errorMessage: string | null = null;
  protected registrationForm: FormGroup;

  protected roleOptions = [
    {value: UserRoleDto.Customer, viewValue: 'Customer'},
    {value: UserRoleDto.Librarian, viewValue: 'Librarian'}
  ];

  protected get email(): FormControl {
    return <FormControl>this.registrationForm.get('email');
  }

  protected get password(): FormControl {
    return <FormControl>this.registrationForm.get('password');
  }

  protected get preferredName(): FormControl {
    return <FormControl>this.registrationForm.get('preferredName');
  }

  protected get role(): FormControl {
    return <FormControl>this.registrationForm.get('role');
  }

  public constructor(
    private logger: LoggingService,
    private authService: AuthService,
    private router: AppRouter,
    private route: ActivatedRoute
  ) {
    this.returnUrl = this.route.snapshot.queryParams['returnUrl'] || NAV_PATHS.ROOT;
    this.registrationForm = new FormGroup({
      email: new FormControl('', [Validators.required, Validators.email]),
      password: new FormControl('', [Validators.required, this.passwordValidator()]),
      preferredName: new FormControl(''),
      role: new FormControl(UserRoleDto.Customer, Validators.required)
    });
  }

  protected onSubmit() {
    this.isLoading = true;
    this.errorMessage = null;
    const email = this.email.value;
    const password = this.password.value;
    const preferredName = this.preferredName.value;
    const role = this.role.value;

    this.authService.registerUser(email, password, preferredName, role)
      .subscribe({
        next: () => {
          this.logger.debug('Registration success, attempting authentication...');
          this.authService.authenticateUser(email, password)
            .subscribe({
              next: () => {
                this.logger.debug('Authentication success, redirecting...');
                this.router.navigate([NAV_PATHS.ROOT]);
              },
              error: (error) => {
                this.logger.error('Authentication error', error);
                this.errorMessage = 'Authentication failed. Please try logging in manually.';
                this.isLoading = false;
              }
            });
        },
        error: (error) => {
          this.logger.error('Registration error', error);
          this.errorMessage = 'Registration failed. Please try again.';
          this.isLoading = false;
        }
      });
  }

  protected passwordValidator(): ValidatorFn  {
    return (control: AbstractControl): ValidationErrors | null => {
      const password = control.value;
      if (!password) {
        return {'required': true};
      }

      const errors: string[] = [];

      if (password.length < 6) {
        errors.push('Password must be at least 6 characters long.');
      }

      if (!/[^a-zA-Z0-9]/.test(password)) {
        errors.push('Password must contain at least one non-alphanumeric character.');
      }

      if (!/\d/.test(password)) {
        errors.push('Password must contain at least one digit.');
      }

      if (!/[a-z]/.test(password)) {
        errors.push('Password must contain at least one lowercase letter.');
      }

      if (!/[A-Z]/.test(password)) {
        errors.push('Password must contain at least one uppercase letter.');
      }

      if (new Set(password).size < 1) {
        errors.push('Password must contain at least 1 unique character.');
      }

      return errors.length > 0 ? {'passwordValidation': errors} : null;
    };
  }
}
