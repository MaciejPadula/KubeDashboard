import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { Deployment } from '../model/deployment';

@Injectable({
  providedIn: 'root'
})
export class AddDeploymentService {

  constructor(
    private httpClient: HttpClient
  ) { }

  public addDeployment(deploy: Deployment): Observable<object> {
    return this.httpClient.post(`/api/AddDeployment`, {
      deploy
    });
  }
}
