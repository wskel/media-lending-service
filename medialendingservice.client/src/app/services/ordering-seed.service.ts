import { Injectable } from '@angular/core';

export const SEED_KEYS = {
  BOOKS: 'BOOKS'
};

@Injectable({
  providedIn: 'root'
})
export class OrderingSeedService {
  private readonly SEED_PREFIX = 'ORDERING_SEED_';

  // ordering will refresh on page reload instead of each search
  public constructor() {
    this.refreshAllSeeds();
  }

  public getOrderingSeed(key: string): string {
    const fullKey = this.getSeedKey(key);
    return localStorage.getItem(fullKey) || this.refreshSeed(key);
  }

  public refreshSeed(key: string): string {
    const fullKey = this.getSeedKey(key);
    const newSeed = crypto.randomUUID();
    localStorage.setItem(fullKey, newSeed);
    return newSeed;
  }

  // noinspection JSUnusedGlobalSymbols
  public clearSeed(key: string): void {
    const fullKey = this.getSeedKey(key);
    localStorage.removeItem(fullKey);
  }

  private getSeedKey(key: string): string {
    return `${this.SEED_PREFIX}${key}`;
  }

  public refreshAllSeeds(): void {
    Object.keys(localStorage)
      .filter(key => key.startsWith(this.SEED_PREFIX))
      .forEach(key => {
        localStorage.setItem(key, crypto.randomUUID());
      });
  }
}
