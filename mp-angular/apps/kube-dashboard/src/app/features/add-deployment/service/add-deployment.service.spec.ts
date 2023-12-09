import { TestBed } from '@angular/core/testing';

import { AddDeploymentService } from './add-deployment.service';

describe('AddDeploymentService', () => {
  let service: AddDeploymentService;

  beforeEach(() => {
    TestBed.configureTestingModule({});
    service = TestBed.inject(AddDeploymentService);
  });

  it('should be created', () => {
    expect(service).toBeTruthy();
  });
});
