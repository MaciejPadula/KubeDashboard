import { Injectable } from '@angular/core';
import { Subject } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class LayoutService {
  private toggleSidenavSubject$ = new Subject<void>();
  public toggleSidenav$ = this.toggleSidenavSubject$.asObservable();

  constructor() { }

  public toggleSidenav() {
    this.toggleSidenavSubject$.next();
  }
}
