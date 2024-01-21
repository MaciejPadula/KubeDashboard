import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable, map } from 'rxjs';
import { Deployment } from '../../../shared/model/deployment';
import { GetDeploymentsResponse } from './response/get-deployments-response';
import { GetDeploymentPodsResponse } from './response/get-pods-response';
import { SettingsService } from '../../../shared/service/settings.service';

@Injectable({
  providedIn: 'root'
})
export class DeploymentsListService {
  constructor(
    private httpClient: HttpClient,
    private settingsService: SettingsService
  ) { }

  public getDeployments(namespace: string): Observable<Deployment[]> {
    return this.httpClient.get<GetDeploymentsResponse>(`${this.settingsService.apiBaseUrl}/api/Deployment/GetDeploymentsList/${namespace}`)
      .pipe(map(x => x.deployments));
  }

  public getPods(deploymentName: string, namespace: string): Observable<GetDeploymentPodsResponse> {
    return this.httpClient.get<GetDeploymentPodsResponse>(`${this.settingsService.apiBaseUrl}/api/Deployment/GetDeploymentPods/${namespace}/${deploymentName}`);
  }
}
