import { TestBed } from '@angular/core/testing';

import { RestaurantApiService } from './restaurant-api.service';

describe('RestaurantApiService', () => {
  let service: RestaurantApiService;

  beforeEach(() => {
    TestBed.configureTestingModule({});
    service = TestBed.inject(RestaurantApiService);
  });

  it('should be created', () => {
    expect(service).toBeTruthy();
  });
});
