import { Component, OnInit, ViewChild } from '@angular/core';
import { CommonModule } from '@angular/common';
import { SharedModule } from '../../shared/shared.module';
import { LayoutService } from '../service/layout.service';
import { MatDrawer } from '@angular/material/sidenav';
import { UntilDestroy, untilDestroyed } from '@ngneat/until-destroy';

@UntilDestroy()
@Component({
  selector: 'mp-angular-sidenav',
  standalone: true,
  imports: [CommonModule, SharedModule],
  templateUrl: './sidenav.component.html',
  styleUrl: './sidenav.component.scss',
})
export class SidenavComponent implements OnInit {
  @ViewChild('drawer') drawer!: MatDrawer;

  constructor(
    private layoutService: LayoutService
  ) {}

  ngOnInit(): void {
    this.layoutService.toggleSidenav$
      .pipe(untilDestroyed(this))
      .subscribe(() => {
        this.drawer.toggle();
      });
  }

}
