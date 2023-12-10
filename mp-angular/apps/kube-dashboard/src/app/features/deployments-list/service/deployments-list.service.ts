import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable, map } from 'rxjs';
import { Deployment } from '../../../shared/model/deployment';
import { GetDeploymentsResponse } from './response/get-deployments-response';
import { GetDeploymentPodsResponse } from './response/get-pods-response';

@Injectable({
  providedIn: 'root'
})
export class DeploymentsListService {

  private readonly baseUrl = 'https://localhost:7128';

  constructor(
    private httpClient: HttpClient
  ) { }

  public getDeployments(namespace: string = 'default'): Observable<Deployment[]> {
    return this.httpClient.get<GetDeploymentsResponse>(`${this.baseUrl}/api/Deployment/GetDeploymentsList/${namespace}`)
      .pipe(map(x => x.deployments));
  }

  public getPods(deploymentName: string, namespace: string): Observable<GetDeploymentPodsResponse> {
    return this.httpClient.get<GetDeploymentPodsResponse>(`${this.baseUrl}/api/Deployment/GetDeploymentPods/${namespace}/${deploymentName}`);
  }
}
