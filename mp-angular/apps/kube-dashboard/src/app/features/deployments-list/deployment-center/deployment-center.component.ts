import { Component, Input, OnInit, signal } from '@angular/core';
import { CommonModule } from '@angular/common';
import { SharedModule } from '../../../shared/shared.module';
import { Deployment } from '../../../shared/model/deployment';
import { DeploymentsListService } from '../service/deployments-list.service';
import { Pod } from '../../../shared/model/pod';
import Chart from 'chart.js/auto';

@Component({
  selector: 'mp-angular-deployment-center',
  standalone: true,
  imports: [CommonModule, SharedModule],
  templateUrl: './deployment-center.component.html',
  styleUrl: './deployment-center.component.scss',
})
export class DeploymentCenterComponent implements OnInit {
  @Input() public deployment: Deployment;
  public chart: Chart<"pie", number[], string>;

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

        this.chart = this.getChart(r.alivePods.length, r.deadPods.length);
      });
  }

  private getChart(alivePods: number, deadPods: number) {
    return new Chart(`pods-chart-${this.deployment.name}`, {
      type: 'pie',
      data: {
        labels: ['Alive', 'Dead',],
        datasets: [{
          label: 'Deployment Pods',
          data: [
            alivePods,
            deadPods
          ],
          backgroundColor: [
            'green',
            'red',
          ],
          hoverOffset: 4
        }],
      },
      options: {
        aspectRatio:2.5
      }
    });
  }
}
