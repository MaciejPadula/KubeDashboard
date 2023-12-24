import { Component } from '@angular/core';
import { CommonModule } from '@angular/common';
import { MaterialModule } from '../../../material.module';

@Component({
  selector: 'mp-angular-error-icon',
  standalone: true,
  imports: [CommonModule, MaterialModule],
  templateUrl: './error-icon.component.html',
})
export class ErrorIconComponent {}
