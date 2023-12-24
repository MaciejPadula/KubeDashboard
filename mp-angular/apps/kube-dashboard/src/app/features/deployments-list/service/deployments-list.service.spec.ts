import { TestBed } from '@angular/core/testing';

import { DeploymentsListService } from './deployments-list.service';

describe('DeploymentsListService', () => {
  let service: DeploymentsListService;

  beforeEach(() => {
    TestBed.configureTestingModule({});
    service = TestBed.inject(DeploymentsListService);
  });

  it('should be created', () => {
    expect(service).toBeTruthy();
  });
});
