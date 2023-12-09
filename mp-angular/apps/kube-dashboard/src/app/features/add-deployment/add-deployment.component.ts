import { Component } from '@angular/core';
import { CommonModule } from '@angular/common';
import { AddDeploymentService } from './service/add-deployment.service';
import { Deployment } from './model/deployment';
import { FormControl } from '@angular/forms';
import { SharedModule } from '../../shared/shared.module';

@Component({
  selector: 'mp-angular-add-deployment',
  standalone: true,
  imports: [CommonModule, SharedModule],
  templateUrl: './add-deployment.component.html',
  styleUrl: './add-deployment.component.scss',
})
export class AddDeploymentComponent {
  public deployForm = new FormControl<Deployment>({});

  constructor(
    private service: AddDeploymentService
  ) {}

  public addDeploy() {
    const value = this.deployForm.value;

    if (!value) {
      return;
    }

    this.service.addDeployment(value);
  }
}
