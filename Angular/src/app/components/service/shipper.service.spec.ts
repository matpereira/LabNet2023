import { TestBed } from '@angular/core/testing';

import { ShipperServiceService } from './shipper.service';

describe('ShipperServiceService', () => {
  let service: ShipperServiceService;

  beforeEach(() => {
    TestBed.configureTestingModule({});
    service = TestBed.inject(ShipperServiceService);
  });

  it('should be created', () => {
    expect(service).toBeTruthy();
  });
});
