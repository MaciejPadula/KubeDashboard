import { ChangeDetectionStrategy, Component } from '@angular/core';
import { CommonModule } from '@angular/common';
import { FormControl, Validators } from '@angular/forms';
import { SharedModule } from '../../shared/shared.module';
import { ServiceType } from '../../shared/model/service-type';
import { LoadBalancerFormComponent } from './load-balancer-form/load-balancer-form.component';

@Component({
  selector: 'mp-angular-create-service',
  standalone: true,
  imports: [CommonModule, SharedModule, LoadBalancerFormComponent],
  templateUrl: './create-service.component.html',
  changeDetection: ChangeDetectionStrategy.OnPush,
})
export class CreateServiceComponent {
  public selectedType = new FormControl<ServiceType | null>(null, [Validators.required, Validators.nullValidator]);

  ServiceType = ServiceType;
}
