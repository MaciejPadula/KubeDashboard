import { Route } from '@angular/router';
import { ListImagesComponent } from './features/list-images/list-images.component';

export const appRoutes: Route[] = [
  { path: 'images', component: ListImagesComponent }
];
