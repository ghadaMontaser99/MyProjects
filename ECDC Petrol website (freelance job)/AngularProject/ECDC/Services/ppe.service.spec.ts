import { TestBed } from '@angular/core/testing';

import { PPEService } from './ppe.service';

describe('PPEService', () => {
  let service: PPEService;

  beforeEach(() => {
    TestBed.configureTestingModule({});
    service = TestBed.inject(PPEService);
  });

  it('should be created', () => {
    expect(service).toBeTruthy();
  });
});
