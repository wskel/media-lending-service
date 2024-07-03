import { Component } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { LoggingService } from '../../services/logging.service';
import { UserRoleDto } from "../../models/user-role.dto";
import { RegisterRequestDto } from "../../models/register-request.dto";

@Component({
  selector: 'app-registration',
  templateUrl: './registration.component.html',
  styleUrl: './registration.component.css'
})
export class RegistrationComponent {
  email: string = '';
  password: string = '';
  preferredName: string | null = null;
  role: UserRoleDto = UserRoleDto.Customer;

  roleOptions = [
    {value: UserRoleDto.Customer, viewValue: 'Customer'},
    {value: UserRoleDto.Librarian, viewValue: 'Librarian'}
  ];

  constructor(private http: HttpClient, private logger: LoggingService) {
  }

  onSubmit() {
    const postData: RegisterRequestDto = {
      email: this.email,
      password: this.password,
      preferredName: this.preferredName,
      role: this.role
    };

    this.http.post('/api/v0/register', postData)
      .subscribe({
        next: (response) => {
          this.logger.debug('Registration success', response);
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
