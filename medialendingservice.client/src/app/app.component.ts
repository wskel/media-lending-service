import { Component, HostListener } from '@angular/core';
import { AuthService } from './services/auth.service';
import { NAV_PATHS } from "./app-routing.module";
import { AppRouter } from "./utils/app-router";

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.scss']
})
export class AppComponent {
  title = 'Media Lending Library';
  isScrolled = false;

  @HostListener('window:scroll', [])
  protected onWindowScroll() {
    const baseFontSize = parseFloat(getComputedStyle(document.documentElement).fontSize);
    const scrollThresholdRem = 3.125;
    const scrollThresholdPx = scrollThresholdRem * baseFontSize;
    this.isScrolled = window.scrollY > scrollThresholdPx;
  }

  public constructor(protected authService: AuthService, private router: AppRouter) {
  }

  protected logout() {
    this.authService.logout();
    this.router.navigate([NAV_PATHS.LOGIN]);
  }
}
