import { ChangeDetectionStrategy, Component, OnInit, signal } from '@angular/core';
import { CommonModule } from '@angular/common';
import { PersonalizationService } from '../../shared/service/personalization.service';
import { NamespaceServiceService } from '../service/namespace-service.service';
import { FormControl } from '@angular/forms';
import { UntilDestroy, untilDestroyed } from '@ngneat/until-destroy';
import { SharedModule } from '../../shared/shared.module';

@UntilDestroy()
@Component({
  selector: 'mp-angular-select-namespace',
  standalone: true,
  imports: [CommonModule, SharedModule],
  templateUrl: './select-namespace.component.html',
  changeDetection: ChangeDetectionStrategy.OnPush,
})
export class SelectNamespaceComponent implements OnInit {
  #namespaces = signal<string[]>([]);
  public namespaces = this.#namespaces.asReadonly();

  public selectedNamespace = this.personalizationService.currentNamespace;

  public selectControl: FormControl<string | null>;
  
  constructor(
    private personalizationService: PersonalizationService,
    private namespaceServiceService: NamespaceServiceService
  ) {}

  public ngOnInit(): void {
    this.selectControl = new FormControl<string>(this.selectedNamespace());

    this.namespaceServiceService.getNamespaces()
      .subscribe({
        next: response => this.#namespaces.set(response.namespaces)
      });

    this.selectControl.valueChanges
      .pipe(
        untilDestroyed(this)
      )
      .subscribe(namespace => {
        if (namespace) {
          this.personalizationService.setCurrentNamespace(namespace);
        }
      })
  }
}
