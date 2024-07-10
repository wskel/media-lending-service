import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { RegistrationComponent } from "./components/registration/registration.component";
import { authGuard } from "./guards/auth.guard";
import { LoginComponent } from "./components/login/login.component";
import { BooksComponent } from "./components/books/books.component";

const PATHS = {
  HOME: '',
  BOOKS: 'books',
  LOGIN: 'login',
  REGISTER: 'register',
  WILDCARD: '**',
};

export const NAV_PATHS = {
  ROOT: `/${PATHS.HOME}`,
  BOOKS: `/${PATHS.BOOKS}`,
  LOGIN: `/${PATHS.LOGIN}`,
  REGISTER: `/${PATHS.REGISTER}`,
};

const routes: Routes = [
  {path: PATHS.HOME, redirectTo: PATHS.BOOKS, pathMatch: 'full'},
  {path: PATHS.BOOKS, component: BooksComponent, canActivate: [authGuard]},
  {path: PATHS.LOGIN, component: LoginComponent},
  {path: PATHS.REGISTER, component: RegistrationComponent},
  {path: PATHS.WILDCARD, redirectTo: PATHS.BOOKS}
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule {
}
