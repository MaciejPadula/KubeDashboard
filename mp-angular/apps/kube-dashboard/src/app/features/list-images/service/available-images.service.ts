import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable, map } from 'rxjs';
import { DockerImage } from '../model/docker-image';
import { GetAvailableImages } from './response/get-available-images-response';

@Injectable({
  providedIn: 'root'
})
export class AvailableImagesService {

  private readonly baseUrl = 'https://localhost:7128';

  constructor(
    private httpClient: HttpClient
  ) { }

  public getAvailableImages(registryBaseUrl: string): Observable<DockerImage[]> {
    return this.httpClient.post<GetAvailableImages>(
      `${this.baseUrl}/api/AvailableImages/GetAvailableImages`, {
        registryBaseUrl
      }).pipe(map(r => r.images));
  }
}
