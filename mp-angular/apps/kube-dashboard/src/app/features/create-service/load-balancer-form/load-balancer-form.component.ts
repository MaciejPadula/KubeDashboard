import { ChangeDetectionStrategy, Component } from '@angular/core';
import { CommonModule } from '@angular/common';
import { SharedModule } from '../../../shared/shared.module';
import { SelectImageComponent } from '../select-image/select-image.component';
import { FormControl, FormGroup, Validators } from '@angular/forms';
import { TaggedImage } from '../../../shared/model/tagged-image';
import { CreateServiceService } from '../service/create-service.service';

@Component({
  selector: 'mp-angular-load-balancer-form',
  standalone: true,
  imports: [CommonModule, SharedModule, SelectImageComponent],
  templateUrl: './load-balancer-form.component.html',
  changeDetection: ChangeDetectionStrategy.OnPush,
})
export class LoadBalancerFormComponent {
  public deployForm = new FormGroup({
    deployName: new FormControl('deploy-name', [Validators.required]),
    serviceName: new FormControl('service-name', [Validators.required]),
    replicas: new FormControl(1, [Validators.required, Validators.min(1)]),
    image: new FormControl<TaggedImage>({ name: '', tag: '' }, [Validators.required])
  });

  constructor(
    private createServiceService: CreateServiceService
  ) {}
}
