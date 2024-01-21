import { Component } from '@angular/core';
import { CommonModule } from '@angular/common';
import { ChangeDetectionStrategy } from '@angular/core';
import { SharedModule } from '../../shared/shared.module';
import { PersonalizationService } from '../../shared/service/personalization.service';
import { NamespaceDeploymentsComponent } from './namespace-deployments/namespace-deployments.component';

@Component({
  selector: 'mp-angular-deployments-list',
  standalone: true,
  imports: [CommonModule, SharedModule, NamespaceDeploymentsComponent],
  templateUrl: './deployments-list.component.html',
  styleUrl: './deployments-list.component.scss',
  changeDetection: ChangeDetectionStrategy.OnPush,
})
export class DeploymentsListComponent {
  public selectedNamespace = this.personalizationService.currentNamespace;

  constructor(
    private personalizationService: PersonalizationService
  ) { }
}
