import { TestBed } from '@angular/core/testing';

import { NamespaceServiceService } from './namespace-service.service';

describe('NamespaceServiceService', () => {
  let service: NamespaceServiceService;

  beforeEach(() => {
    TestBed.configureTestingModule({});
    service = TestBed.inject(NamespaceServiceService);
  });

  it('should be created', () => {
    expect(service).toBeTruthy();
  });
});
