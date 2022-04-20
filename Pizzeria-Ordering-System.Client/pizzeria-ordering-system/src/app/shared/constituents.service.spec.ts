import { HttpClientModule } from '@angular/common/http';
import { TestBed } from '@angular/core/testing';

import { ConstituentsService } from './constituents.service';

describe('ConstituentsService', () => {
  let service: ConstituentsService;

  beforeEach(() => {
    TestBed.configureTestingModule({
      imports: [HttpClientModule]
    });
    service = TestBed.inject(ConstituentsService);
  });

  it('should be created', () => {
    expect(service).toBeTruthy();
  });

  it('should be get all ingredients on pizza', () => {
    expect(service.getAllConstituents).toBeDefined();
  });

  it('should be getting toppings on pizza', () => {
    expect(service.getToppings).toBeDefined();
  });
  
  it('should be get crust on pizza', () => {
    expect(service.getCrust).toBeDefined();
  });
  
  it('should be get sauce on pizza', () => {
    expect(service.getSauce).toBeDefined();
  });
  
  it('should be get sizes on pizza', () => {
    expect(service.getPizzaSize).toBeDefined();
  });
  
  it('should be get ingredient by id', () => {
    expect(service.getConstituentById).toBeDefined();
  });
});
