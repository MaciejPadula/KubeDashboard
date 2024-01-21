import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { SettingsService } from '../../shared/service/settings.service';
import { GetNamespacesResponse } from '../../shared/model/response/get-namespaces-response';

@Injectable({
  providedIn: 'root'
})
export class NamespaceServiceService {
  constructor(
    private httpClient: HttpClient,
    private settingsService: SettingsService
  ) { }

  public getNamespaces() {
    return this.httpClient.get<GetNamespacesResponse>(`${this.settingsService.apiBaseUrl}/api/Namespace/GetNamespaces`);
  }
}
