import { Router, NavigationExtras, UrlTree, NavigationBehaviorOptions } from '@angular/router';
import { LoggingService } from '../services/logging.service';
import { Injectable } from '@angular/core';

@Injectable({
  providedIn: 'root'
})
export class AppRouter {

  public constructor(private router: Router, private logger: LoggingService) {
  }

  public navigate(commands: any[], extras?: NavigationExtras) {
    this.router.navigate(commands, extras)
      .then(result => {
        this.logger.debug(`Navigation to ${commands} ${result ? 'succeeded' : 'failed'}`);
      })
      .catch(error => {
        this.logger.error(`Navigation to ${commands} failed with an error`, error);
      });
  }

  public navigateByUrl(url: string | UrlTree, extras?: NavigationBehaviorOptions) {
    this.router.navigateByUrl(url, extras)
      .then(result => {
        this.logger.debug(`Navigation to ${url} ${result ? 'succeeded' : 'failed'}`);
      })
      .catch(error => {
        this.logger.error(`Navigation to ${url} failed with an error`, error);
      });
  }
}
