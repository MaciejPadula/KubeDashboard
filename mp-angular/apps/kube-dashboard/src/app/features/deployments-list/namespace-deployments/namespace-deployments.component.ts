import { ChangeDetectionStrategy, Component, Input, OnChanges, signal } from '@angular/core';
import { CommonModule } from '@angular/common';
import { SharedModule } from '../../../shared/shared.module';
import { Deployment } from '../../../shared/model/deployment';
import { StatusIconComponent } from '../../../shared/components/status-icon/status-icon.component';
import { DeploymentsListService } from '../service/deployments-list.service';
import { Status } from '../../../shared/components/status-icon/status';
import { DeploymentCenterComponent } from '../deployment-center/deployment-center.component';

@Component({
  selector: 'mp-angular-namespace-deployments',
  standalone: true,
  imports: [CommonModule, SharedModule, StatusIconComponent, DeploymentCenterComponent],
  templateUrl: './namespace-deployments.component.html',
  changeDetection: ChangeDetectionStrategy.OnPush,
})
export class NamespaceDeploymentsComponent implements OnChanges {
  #deployments = signal<Deployment[]>([]);
  public deployments = this.#deployments.asReadonly();

  @Input() public namespace: string;

  constructor(
    private deploymentsListService: DeploymentsListService,
  ) {}

  public getStatusOfDeployment(deployment: Deployment): Status {
    if (deployment.aliveReplicas === deployment.replicas) {
      return Status.Success;
    }

    if (deployment.aliveReplicas === 0) {
      return Status.Error;
    }

    return Status.Warning;
  }

  public ngOnChanges() {
    this.deploymentsListService.getDeployments(this.namespace)
      .subscribe(r => this.#deployments.set(r));
  }
}
