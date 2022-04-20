import { HttpClientModule } from '@angular/common/http';
import { ComponentFixture, TestBed } from '@angular/core/testing';
import { ReactiveFormsModule } from '@angular/forms';
import { RouterTestingModule } from '@angular/router/testing';
import { ToastrModule } from 'ngx-toastr';
import { of } from 'rxjs';
import { IConstituents } from 'src/app/models/i.constituents';
import { IPizza } from 'src/app/models/i.pizza';
import { IPizzaSize } from 'src/app/models/i.pizza-size';
import { SizeType } from 'src/app/models/size-time.enum';
import { ConstituentsService } from 'src/app/shared/constituents.service';
import { PizzaOrderService } from 'src/app/shared/pizzaorder.service';
import { BakePizzaComponent } from './bake-pizza.component';

describe('BakePizzaComponent', () => {
  let component: BakePizzaComponent;
  let fixture: ComponentFixture<BakePizzaComponent>;
  let constituentService: ConstituentsService;
  let pizzaOrderService: PizzaOrderService;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ BakePizzaComponent ],
      imports: [ReactiveFormsModule, HttpClientModule, RouterTestingModule, ToastrModule.forRoot()]
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

  let pizzaSize: IPizzaSize = {
    name : SizeType.Small,
    id: 1,
    multipler: 1
  } 

  let pizzaSizeMedium: IPizzaSize = {
    name : SizeType.Medium,
    id: 2,
    multipler: 2
  } 

  let pizzaSizeArray: IPizzaSize[] = [];
  pizzaSizeArray.push(pizzaSize);
  pizzaSizeArray.push(pizzaSizeMedium);

  beforeEach(() => {
    fixture = TestBed.createComponent(BakePizzaComponent);
    component = fixture.componentInstance;
    constituentService = TestBed.inject(ConstituentsService);
    pizzaOrderService = TestBed.inject(PizzaOrderService);
    fixture.detectChanges();
  });

  it('should create.', () => {
    expect(component).toBeTruthy();
  });

  it('should have default value.', () => {
    expect(component.customPizzaForm).toBeDefined();
    expect(component.pizzas).toBeDefined();
    expect(component.selectedPizza).toBeUndefined();
    expect(component.selectedConstituents).toBeDefined();
    expect(component.sizes).toBeUndefined();
    expect(component.toppings).toBeUndefined();
    expect(component.crust).toBeUndefined();
    expect(component.sauce).toBeUndefined();
  });

  it('should load all the custom pizza form with default values and get all sizes.', () => {
    spyOn(component, 'createPizzaForm');
    spyOn(component, 'getAllPizza');
    spyOn(component, 'getSauce');
    spyOn(component, 'getExtraCheese');
    spyOn(component, 'getAllCrust');
    spyOn(component, 'getAllToppings');
    spyOn(component, 'getPizzaSizes');
    component.ngOnInit();
    expect(component.createPizzaForm).toHaveBeenCalled();
    expect(component.getAllPizza).toHaveBeenCalled();
    expect(component.getSauce).toHaveBeenCalled();
    expect(component.getExtraCheese).toHaveBeenCalled();
    expect(component.getAllCrust).toHaveBeenCalled();
    expect(component.getAllToppings).toHaveBeenCalled();
    expect(component.getPizzaSizes).toHaveBeenCalled();
  });

  it('should verify all the pizzas from Pizza Order service', () => {
    spyOn(pizzaOrderService, 'getAllPizza').and.returnValue(of([pizza]));
    component.getAllPizza();
    expect(component.pizzas.length).toEqual(1);
    expect(component.pizzas[0].name).toEqual("Customized Pizza");
    expect(component.pizzas[0].constituents[0].name).toEqual("Green Capsicum Test");
  });

  it('should get selected pizza detail', () => {
    spyOn(pizzaOrderService, 'getPizzaById').and.returnValue(of(pizza));
    component.customPizzaForm.controls.pizzaId.setValue(1);
    component.onPizzaSelectedEvent({target: {value: 1}});
    expect(component.selectedPizza).toEqual(pizza);
  });


  it('should get all Sauce', () => {
    spyOn(constituentService, 'getSauce').and.returnValue(of([constituents]));
    component.getSauce();
    expect(component.sauce.length).toEqual(1);
  });

  it('should calculate price on  select sauce', () => {
    spyOn(component, 'priceByConstituents');
    component.customPizzaForm.controls.sauceId.setValue(1);
    component.onSauceSelectedEvent({});
    expect(component.priceByConstituents).toHaveBeenCalled();
  });

  it('should get all toppings', () => {
    spyOn(constituentService, 'getToppings').and.returnValue(of([constituents]));
    component.getAllToppings();
    expect(component.toppings.length).toEqual(1);
  });

  it('should calculate price on  select toppings', () => {
    spyOn(component, 'priceByConstituents');
    component.customPizzaForm.controls.toppingId.setValue(1);
    component.onToppingSelectedEvent({});
    expect(component.priceByConstituents).toHaveBeenCalled();
  });

  it('should get all crust', () => {
    spyOn(constituentService, 'getCrust').and.returnValue(of([constituents]));
    component.getAllCrust();
    expect(component.crust.length).toEqual(1);
  });

  it('should calculate price on  select crust', () => {
    spyOn(component, 'priceByConstituents');
    component.customPizzaForm.controls.crustId.setValue(1);
    component.onCrustSelectedEvent({});
    expect(component.priceByConstituents).toHaveBeenCalled();
  });

  it('should get all sizes', () => {
    spyOn(constituentService, 'getPizzaSize').and.returnValue(of([pizzaSize]));
    component.getPizzaSizes();
    expect(component.sizes.length).toEqual(1);
  });

  it('should calculate price on  select size', () => {
    spyOn(component, 'priceByConstituents');
    component.customPizzaForm.controls.sizeId.setValue(2);
    component.selectedPizza = pizza;
    component.onPizzaSelectedEvent({});
    expect(component.selectedPizza.price).not.toEqual(0);
  });

  it('should calculate price for adding cheese', () => {
    expect(component.onAddCheeseChangeEvent).toBeDefined();
  });

  it('should calculate price for adding extra cheese', () => {
    expect(component.onAddExtraCheeseChangeEvent).toBeDefined();
  });

  it('should create custom pizza order', () => {
    spyOn(pizzaOrderService, 'bakeCustomizedPizza').and.returnValue(of());
    component.customPizzaForm.controls.numberOfPizza.setValue(1);
    component.customPizzaForm.controls.isAddCheese.setValue(true);
    component.customPizzaForm.controls.isAddExtraCheese.setValue(true);
    component.customPizzaForm.controls.sizeId.setValue("Medium");
    component.selectedConstituents = constituentArray;
    component.sizes = pizzaSizeArray;
    component.selectedPizza = pizza;
    component.selectedPizza.id = 99;
    component.onBakePizza();
    expect(pizzaOrderService.bakeCustomizedPizza).toHaveBeenCalled();
  });

});
