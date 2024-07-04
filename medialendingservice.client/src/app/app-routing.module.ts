import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { RegistrationComponent } from "./components/registration/registration.component";
import { AppComponent } from "./app.component";
import { authGuard } from "./guards/auth.guard";
import { LoginComponent } from "./components/login/login.component";

export const PATHS = {
  ROOT: '/',
  LOGIN: 'login',
  REGISTER: 'register'
};

const HOME = '';
const WILDCARD = '**';

const routes: Routes = [
  {path: HOME, component: AppComponent, canActivate: [authGuard]},
  {path: 'books', component: AppComponent, canActivate: [authGuard]},
  {path: PATHS.LOGIN, component: LoginComponent},
  {path: PATHS.REGISTER, component: RegistrationComponent},
  {path: WILDCARD, redirectTo: ''}
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule {
}
