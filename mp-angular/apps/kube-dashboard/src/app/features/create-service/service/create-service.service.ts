import { Injectable } from '@angular/core';
import { SettingsService } from '../../../shared/service/settings.service';
import { CreateDeploymentRequest } from '../model/create-deployment-request';
import { HttpClient } from '@angular/common/http';

@Injectable({
  providedIn: 'root'
})
export class CreateServiceService {

  constructor(
    private httpClient: HttpClient,
    private settingsService: SettingsService
  ) { }

  public createService() {

  }

  public createDeployment(deploy: CreateDeploymentRequest) {
    this.httpClient.post(this.settingsService.apiBaseUrl + '/deployments', deploy)
      .subscribe();
  }
}
