import { Component, Input } from '@angular/core';
import { CommonModule } from '@angular/common';
import { ErrorIconComponent } from './error-icon/error-icon.component';
import { WarningIconComponent } from './warning-icon/warning-icon.component';
import { SuccessIconComponent } from './success-icon/success-icon.component';
import { Status } from './status';

@Component({
  selector: 'mp-angular-status-icon',
  standalone: true,
  imports: [CommonModule, ErrorIconComponent, SuccessIconComponent, WarningIconComponent],
  templateUrl: './status-icon.component.html',
})
export class StatusIconComponent {
  @Input() status: Status;

  public Status = Status;
}
