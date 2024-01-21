import { Injectable } from '@angular/core';

@Injectable({
  providedIn: 'root'
})
export class SettingsService {

  constructor() { }

  public get apiBaseUrl(): string {
    return 'https://localhost:7128';
  }
}
