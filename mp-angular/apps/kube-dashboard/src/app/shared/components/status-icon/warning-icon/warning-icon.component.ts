import { Component } from '@angular/core';
import { CommonModule } from '@angular/common';
import { MaterialModule } from '../../../material.module';

@Component({
  selector: 'mp-angular-warning-icon',
  standalone: true,
  imports: [CommonModule, MaterialModule],
  templateUrl: './warning-icon.component.html',
})
export class WarningIconComponent {}
