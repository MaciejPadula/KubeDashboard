import { ChangeDetectionStrategy, Component } from '@angular/core';
import { CommonModule } from '@angular/common';
import { SharedModule } from '../../shared/shared.module';
import { LayoutService } from '../service/layout.service';
import { SelectNamespaceComponent } from '../select-namespace/select-namespace.component';

@Component({
  selector: 'mp-angular-navbar',
  standalone: true,
  imports: [CommonModule, SharedModule, SelectNamespaceComponent],
  templateUrl: './navbar.component.html',
  styleUrl: './navbar.component.scss',
  changeDetection: ChangeDetectionStrategy.OnPush,
})
export class NavbarComponent {
  constructor(
    private layoutService: LayoutService
  ){}

  public toggleSidenav() {
    this.layoutService.toggleSidenav();
  }
}
