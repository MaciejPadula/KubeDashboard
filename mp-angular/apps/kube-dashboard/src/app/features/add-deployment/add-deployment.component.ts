import { ChangeDetectionStrategy, Component } from '@angular/core';
import { CommonModule } from '@angular/common';
import { AddDeploymentService } from './service/add-deployment.service';
import { FormControl } from '@angular/forms';
import { SharedModule } from '../../shared/shared.module';
import { Deployment } from '../../shared/model/deployment';

@Component({
  selector: 'mp-angular-add-deployment',
  standalone: true,
  imports: [CommonModule, SharedModule],
  templateUrl: './add-deployment.component.html',
  styleUrl: './add-deployment.component.scss',
  changeDetection: ChangeDetectionStrategy.OnPush
})
export class AddDeploymentComponent {
  public deployForm = new FormControl<Deployment>({name: "", replicas: 0, namespace: ''});

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
