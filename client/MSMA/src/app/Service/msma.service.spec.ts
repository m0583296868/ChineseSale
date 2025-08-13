import { TestBed } from '@angular/core/testing';

import { MsmaService } from './msma.service';

describe('MsmaService', () => {
  let service: MsmaService;

  beforeEach(() => {
    TestBed.configureTestingModule({});
    service = TestBed.inject(MsmaService);
  });

  it('should be created', () => {
    expect(service).toBeTruthy();
  });
});
