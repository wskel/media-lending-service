import { NgModule } from '@angular/core';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { BrowserModule } from '@angular/platform-browser';
import { HTTP_INTERCEPTORS, provideHttpClient, withInterceptorsFromDi } from '@angular/common/http';
import { BrowserAnimationsModule } from "@angular/platform-browser/animations";
import { MatInputModule } from "@angular/material/input";
import { MatButtonModule } from "@angular/material/button";
import { MatFormFieldModule } from "@angular/material/form-field";
import { provideAnimationsAsync } from "@angular/platform-browser/animations/async";

import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { RegistrationComponent } from './components/registration/registration.component';
import { MatOption } from "@angular/material/core";
import { MatSelect } from "@angular/material/select";
import { LoginComponent } from './components/login/login.component';
import { BooksComponent } from './components/books/books.component';
import { MatCardModule } from "@angular/material/card";
import { AuthInterceptor } from "./interceptors/auth.interceptor";
import { MatToolbar } from "@angular/material/toolbar";
import { FormatDateOnlyPipe } from './pipes/format-date-only.pipe';
import { NgOptimizedImage } from "@angular/common";
import { MatProgressSpinner } from "@angular/material/progress-spinner";

@NgModule({
  declarations: [
    AppComponent,
    RegistrationComponent,
    LoginComponent,
    BooksComponent,
    FormatDateOnlyPipe,
  ],
  imports: [
    BrowserModule,
    FormsModule,
    ReactiveFormsModule,
    AppRoutingModule,
    BrowserAnimationsModule,
    MatInputModule,
    MatButtonModule,
    MatFormFieldModule,
    MatOption,
    MatSelect,
    MatCardModule,
    MatToolbar,
    NgOptimizedImage,
    MatProgressSpinner,
  ],
  providers: [
    provideHttpClient(withInterceptorsFromDi()),
    provideAnimationsAsync(),
    {
      provide: HTTP_INTERCEPTORS,
      useClass: AuthInterceptor,
      multi: true
    }
  ],
  bootstrap: [AppComponent]
})
export class AppModule {
}
