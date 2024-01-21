import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable, map } from 'rxjs';
import { DockerImage } from '../model/docker-image';
import { GetAvailableImages } from '../model/response/get-available-images-response';
import { SettingsService } from './settings.service';

@Injectable({
  providedIn: 'root'
})
export class AvailableImagesService {
  constructor(
    private httpClient: HttpClient,
    private settingsService: SettingsService
  ) { }

  public getAvailableImages(registryBaseUrl: string): Observable<DockerImage[]> {
    return this.httpClient.post<GetAvailableImages>(
      `${this.settingsService.apiBaseUrl}/api/AvailableImages/GetAvailableImages`, {
        registryBaseUrl
      }).pipe(map(r => r.images));
  }
}
