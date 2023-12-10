import { Component, OnInit, signal } from '@angular/core';
import { CommonModule } from '@angular/common';
import { Deployment } from '../../shared/model/deployment';
import { DeploymentsListService } from './service/deployments-list.service';
import { ChangeDetectionStrategy } from '@angular/core';
import { MaterialModule } from '../../shared/material.module';
import { SharedModule } from '../../shared/shared.module';
import { DeploymentCenterComponent } from './deployment-center/deployment-center.component';

@Component({
  selector: 'mp-angular-deployments-list',
  standalone: true,
  imports: [CommonModule, MaterialModule, SharedModule, DeploymentCenterComponent],
  templateUrl: './deployments-list.component.html',
  styleUrl: './deployments-list.component.scss',
  changeDetection: ChangeDetectionStrategy.OnPush
})
export class DeploymentsListComponent implements OnInit {
  #deployments = signal<Deployment[]>([]);
  public deployments = this.#deployments.asReadonly();

  constructor(
    private deploymentsListService: DeploymentsListService
  ) { }

  ngOnInit(): void {
    this.deploymentsListService.getDeployments()
      .subscribe(r => this.#deployments.set(r));
  }
}
