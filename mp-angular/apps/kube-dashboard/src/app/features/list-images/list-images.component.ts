import { ChangeDetectionStrategy, Component, OnInit, signal } from '@angular/core';
import { CommonModule } from '@angular/common';
import { AvailableImagesService } from '../../shared/service/available-images.service';
import { DockerImage } from '../../shared/model/docker-image';
import { MaterialModule } from '../../shared/material.module';
import { SharedModule } from '../../shared/shared.module';

@Component({
  selector: 'mp-angular-list-images',
  standalone: true,
  imports: [CommonModule, MaterialModule, SharedModule],
  templateUrl: './list-images.component.html',
  styleUrl: './list-images.component.scss',
  changeDetection: ChangeDetectionStrategy.OnPush
})
export class ListImagesComponent implements OnInit {
  #images = signal<DockerImage[]>([]);
  public images = this.#images.asReadonly();

  constructor(
    private availableImagesService: AvailableImagesService
  ) {}

  public ngOnInit(): void {
    this.availableImagesService.getAvailableImages('http://172.30.0.1:5000')
      .subscribe(imgs => this.#images.set(imgs));
  }
}
