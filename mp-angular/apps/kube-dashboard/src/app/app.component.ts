import { ChangeDetectionStrategy, Component, OnInit } from '@angular/core';
import { RouterModule } from '@angular/router';
import { NavbarComponent } from './layout/navbar/navbar.component';
import { SharedModule } from './shared/shared.module';
import { SidenavComponent } from './layout/sidenav/sidenav.component';
import { PersonalizationService } from './shared/service/personalization.service';

@Component({
  standalone: true,
  imports: [RouterModule, NavbarComponent, SidenavComponent, SharedModule],
  selector: 'mp-angular-root',
  templateUrl: './app.component.html',
  styleUrl: './app.component.scss',
  changeDetection: ChangeDetectionStrategy.OnPush,
})
export class AppComponent implements OnInit {
  title = 'kube-dashboard';

  constructor(
    private personalizationService: PersonalizationService
  ){}

  public ngOnInit(): void {
    this.personalizationService.init();
  }
}
