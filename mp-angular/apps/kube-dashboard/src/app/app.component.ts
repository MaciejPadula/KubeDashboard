import { ChangeDetectionStrategy, Component } from '@angular/core';
import { RouterModule } from '@angular/router';
import { NavbarComponent } from './layout/navbar/navbar.component';
import { SharedModule } from './shared/shared.module';
import { SidenavComponent } from './layout/sidenav/sidenav.component';
import { AddDeploymentComponent } from './features/add-deployment/add-deployment.component';

@Component({
  standalone: true,
  imports: [RouterModule, NavbarComponent, SidenavComponent, SharedModule, AddDeploymentComponent],
  selector: 'mp-angular-root',
  templateUrl: './app.component.html',
  styleUrl: './app.component.scss',
  changeDetection: ChangeDetectionStrategy.OnPush,
})
export class AppComponent {
  title = 'kube-dashboard';
}
