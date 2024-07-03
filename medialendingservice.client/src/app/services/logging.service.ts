import { Injectable } from '@angular/core';
import { environment } from '../../environments/environment';

@Injectable({
  providedIn: 'root',
})
export class LoggingService {
  private static readonly OFF = "off"
  private static readonly LOG_LEVELS = new Map<string, number>([
    ['debug', 0],
    ['info', 1],
    ['warn', 2],
    ['error', 3]
  ]);

  private logLevel = environment.logging.level;

  private isDebugEnabled = false;
  private isInfoEnabled = false;
  private isWarnEnabled = false;
  private isErrorEnabled = false;

  constructor() {
    this.setLogFlags();
  }

  private static getLogLevelIndex(level: string): number {
    return LoggingService.LOG_LEVELS.get(level)
      ?? LoggingService.LOG_LEVELS.size;
  }

  private setLogFlags() {
    if (this.logLevel !== LoggingService.OFF) {
      const logLevelIndex = LoggingService.getLogLevelIndex(this.logLevel)

      const isEnabled = (level: string) =>
        logLevelIndex <= LoggingService.getLogLevelIndex(level);

      this.isDebugEnabled = isEnabled('debug');
      this.isInfoEnabled = isEnabled('info');
      this.isWarnEnabled = isEnabled('warn');
      this.isErrorEnabled = isEnabled('error');
    }
  }

  debug(message: string, ...optionalParams: any[]) {
    if (this.isDebugEnabled) {
      console.debug(message, ...optionalParams);
    }
  }

  info(message: string, ...optionalParams: any[]) {
    if (this.isInfoEnabled) {
      console.info(message, ...optionalParams);
    }
  }

  warn(message: string, ...optionalParams: any[]) {
    if (this.isWarnEnabled) {
      console.warn(message, ...optionalParams);
    }
  }

  error(message: string, ...optionalParams: any[]) {
    if (this.isErrorEnabled) {
      console.error(message, ...optionalParams);
    }
  }
}
