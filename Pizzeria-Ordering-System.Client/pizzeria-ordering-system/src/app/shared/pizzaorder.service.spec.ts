import { HttpClientModule } from '@angular/common/http';
import { TestBed } from '@angular/core/testing';

import { PizzaOrderService } from './pizzaorder.service';

describe('PizzaOrderService', () => {
  let service: PizzaOrderService;
  
  beforeEach(() => {
    TestBed.configureTestingModule({
      imports: [HttpClientModule]
    });
    service = TestBed.inject(PizzaOrderService);
  });

  it('should be created', () => {
    expect(service).toBeTruthy();
  });

  it('should be get all pizza', () => {
    expect(service.getAllPizza).toBeDefined();
  });

  it('should be get Pizza By Id', () => {
    expect(service.getPizzaById).toBeDefined();
  });
  
  it('should be bake customized pizza', () => {
    expect(service.bakeCustomizedPizza).toBeDefined();
  });
  
  it('should be available bake pizza', () => {
    expect(service.bakePizza).toBeDefined();
  });
});
