import { HttpClientModule } from '@angular/common/http';
import { ComponentFixture, TestBed } from '@angular/core/testing';
import { of } from 'rxjs';
import { IConstituents } from 'src/app/models/i.constituents';
import { IPizza } from 'src/app/models/i.pizza';
import { ISideBeverages } from 'src/app/models/i.side-beverages';
import { PizzaOrderService } from 'src/app/shared/pizzaorder.service';

import { MenuComponent } from './menu.component';

describe('MenuComponent', () => {
  let component: MenuComponent;
  let fixture: ComponentFixture<MenuComponent>;
  let pizzaOrderService: PizzaOrderService;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ MenuComponent ],
      imports: [HttpClientModule]
    })
    .compileComponents();
  });

  let constituents: IConstituents = {
    id: 1,
    name: 'Green Capsicum Test',
    price: 60
  }

  let constituentArray: IConstituents[] = [];

  constituentArray.push(constituents); 
  
  let pizza: IPizza = {
    id: 1,
    name: 'Customized Pizza',
    price: 360,
    imageUrl: "https://dummyUrl.com",
    description: "Test Veggie Pizza",
    constituents : constituentArray
  }

  
  let sideBeverages: ISideBeverages = {
    id: 1,
    name: 'Garlic Bread Stick',
    price: 300,
    imageUrl: "https://dummyUrl.com",
    description: "The endearing tang of garlic in breadstics baked to perfection",
    beverageConstituents : "Garlic Bread Stick, Coke, With Cheese",
    beverageType : "Garlic Bread"
  }

  beforeEach(() => {
    fixture = TestBed.createComponent(MenuComponent);
    component = fixture.componentInstance;
    pizzaOrderService = TestBed.inject(PizzaOrderService);
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });

  it('should have default value.', () => {
    expect(component.pizzas).toBeDefined();
  });

  it('should verify all the pizzas from Pizza Order service', () => {
    spyOn(pizzaOrderService, 'getAllPizza').and.returnValue(of([pizza]));
    spyOn(pizzaOrderService, 'getAllSideBeverages').and.returnValue(of([sideBeverages]));
    component.ngOnInit();
    expect(component.pizzas.length).toEqual(1);
    expect(component.pizzas[0].name).toEqual("Customized Pizza");
    expect(component.pizzas[0].constituents[0].name).toEqual("Green Capsicum Test");
    expect(component.sideBeverages.length).toEqual(1);
    expect(component.sideBeverages[0].name).toEqual("Garlic Bread Stick");
    expect(component.sideBeverages[0].price).toEqual(300);
    fixture.detectChanges();
  });

});
