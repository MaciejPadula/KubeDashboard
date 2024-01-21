import { MatButtonModule } from '@angular/material/button';
import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { MatIconModule } from '@angular/material/icon';
import { MatToolbarModule } from '@angular/material/toolbar';
import { MatSelectModule } from '@angular/material/select';
import { MatFormFieldModule } from '@angular/material/form-field';
import { MatSidenavModule } from '@angular/material/sidenav';
import { MatExpansionModule } from '@angular/material/expansion';
import { MatStepperModule } from '@angular/material/stepper';
import { MatInputModule } from '@angular/material/input';
import { MatRadioModule } from '@angular/material/radio';

@NgModule({
  declarations: [],
  imports: [
    CommonModule,
    MatIconModule,
    MatButtonModule,
    MatToolbarModule,
    MatSelectModule,
    MatFormFieldModule,
    MatSidenavModule,
    MatExpansionModule,
    MatStepperModule,
    MatInputModule,
    MatRadioModule,
  ],
  exports: [
    MatIconModule,
    MatButtonModule,
    MatToolbarModule,
    MatSelectModule,
    MatFormFieldModule,
    MatSidenavModule,
    MatExpansionModule,
    MatStepperModule,
    MatInputModule,
    MatRadioModule,
  ]
})
export class MaterialModule { }
