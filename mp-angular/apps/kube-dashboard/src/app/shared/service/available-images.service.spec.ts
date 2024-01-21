import { TestBed } from '@angular/core/testing';

import { AvailableImagesService } from './available-images.service';

describe('AvailableImagesService', () => {
  let service: AvailableImagesService;

  beforeEach(() => {
    TestBed.configureTestingModule({});
    service = TestBed.inject(AvailableImagesService);
  });

  it('should be created', () => {
    expect(service).toBeTruthy();
  });
});
