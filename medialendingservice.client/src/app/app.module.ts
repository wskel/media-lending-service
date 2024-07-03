import { NgModule } from '@angular/core';
import { FormsModule } from '@angular/forms';
import { BrowserModule } from '@angular/platform-browser';
import { provideHttpClient } from '@angular/common/http';
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

@NgModule({
  declarations: [
    AppComponent,
    RegistrationComponent,
  ],
  imports: [
    BrowserModule,
    FormsModule,
    AppRoutingModule,
    BrowserAnimationsModule,
    MatInputModule,
    MatButtonModule,
    MatFormFieldModule,
    MatOption,
    MatSelect
  ],
  providers: [
    provideHttpClient(),
    provideAnimationsAsync(),
  ],
  bootstrap: [AppComponent]
})
export class AppModule {
}
