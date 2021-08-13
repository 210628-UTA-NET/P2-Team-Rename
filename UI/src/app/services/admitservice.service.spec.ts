import { TestBed } from '@angular/core/testing';

import { AdmitserviceService } from './admitservice.service';

describe('AdmitserviceService', () => {
  let service: AdmitserviceService;

  beforeEach(() => {
    TestBed.configureTestingModule({});
    service = TestBed.inject(AdmitserviceService);
  });

  it('should be created', () => {
    expect(service).toBeTruthy();
  });
});
