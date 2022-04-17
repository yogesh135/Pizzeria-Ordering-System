import { TestBed } from '@angular/core/testing';

import { ConstituentsService } from './constituents.service';

describe('ConstituentsService', () => {
  let service: ConstituentsService;

  beforeEach(() => {
    TestBed.configureTestingModule({});
    service = TestBed.inject(ConstituentsService);
  });

  it('should be created', () => {
    expect(service).toBeTruthy();
  });
});
