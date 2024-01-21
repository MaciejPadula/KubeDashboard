import { ChangeDetectionStrategy, Component, signal } from '@angular/core';
import { CommonModule } from '@angular/common';
import { DockerImage } from '../../../shared/model/docker-image';
import { PersonalizationService } from '../../../shared/service/personalization.service';
import { AvailableImagesService } from '../../../shared/service/available-images.service';

@Component({
  selector: 'mp-angular-select-image',
  standalone: true,
  imports: [CommonModule],
  templateUrl: './select-image.component.html',
  changeDetection: ChangeDetectionStrategy.OnPush,
})
export class SelectImageComponent {
  #images = signal<DockerImage[]>([]);
  public images = this.#images.asReadonly();

  constructor(
    private availableImagesService: AvailableImagesService,
    private selectedRegistryService: PersonalizationService
  ) {
    this.availableImagesService.getAvailableImages(this.selectedRegistryService.currentRegistry.url)
      .subscribe({
        next: images => this.#images.set(images)
      });
  }
}
