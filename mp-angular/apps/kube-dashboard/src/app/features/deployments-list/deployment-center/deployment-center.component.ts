import { Component, Input, OnInit, signal } from '@angular/core';
import { CommonModule } from '@angular/common';
import { SharedModule } from '../../../shared/shared.module';
import { Deployment } from '../../../shared/model/deployment';
import { DeploymentsListService } from '../service/deployments-list.service';
import { Pod } from '../../../shared/model/pod';

@Component({
  selector: 'mp-angular-deployment-center',
  standalone: true,
  imports: [CommonModule, SharedModule],
  templateUrl: './deployment-center.component.html',
  styleUrl: './deployment-center.component.scss',
})
export class DeploymentCenterComponent implements OnInit {
  @Input() public deployment: Deployment;

  #alivePods = signal<Pod[]>([]);
  public alivePods = this.#alivePods.asReadonly();

  #deadPods = signal<Pod[]>([]);
  public deadPods = this.#deadPods.asReadonly();

  constructor(
    private deploymentsListService: DeploymentsListService
  ) { }

  ngOnInit(): void {
    this.deploymentsListService.getPods(this.deployment.name, this.deployment.namespace)
      .subscribe(r => {
        this.#alivePods.set(r.alivePods);
        this.#deadPods.set(r.deadPods);
      });
  }
}
