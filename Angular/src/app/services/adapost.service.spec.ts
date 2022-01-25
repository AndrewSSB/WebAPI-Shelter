import { TestBed } from '@angular/core/testing';

import { AdapostService } from './adapost.service';

describe('AdapostService', () => {
  let service: AdapostService;

  beforeEach(() => {
    TestBed.configureTestingModule({});
    service = TestBed.inject(AdapostService);
  });

  it('should be created', () => {
    expect(service).toBeTruthy();
  });
});
