import { Route } from '@angular/router';
import { ListImagesComponent } from './features/list-images/list-images.component';
import { DeploymentsListComponent } from './features/deployments-list/deployments-list.component';
import { CreateServiceComponent } from './features/create-service/create-service.component';

export const appRoutes: Route[] = [
  { path: 'images', component: ListImagesComponent },
  { path: 'deployments', component: DeploymentsListComponent },
  { path: 'create-service', component: CreateServiceComponent },
];
