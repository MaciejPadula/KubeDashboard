import { Component } from '@angular/core';
import { CommonModule } from '@angular/common';
import { MaterialModule } from '../../../material.module';

@Component({
  selector: 'mp-angular-success-icon',
  standalone: true,
  imports: [CommonModule, MaterialModule],
  templateUrl: './success-icon.component.html',
})
export class SuccessIconComponent {}
