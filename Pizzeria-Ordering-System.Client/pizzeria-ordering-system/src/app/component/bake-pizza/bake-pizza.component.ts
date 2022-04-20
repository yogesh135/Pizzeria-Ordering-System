import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { Router } from '@angular/router';
import { ToastrService } from 'ngx-toastr';
import { IConstituents } from 'src/app/models/i.constituents';
import { IPizza } from 'src/app/models/i.pizza';
import { IPizzaOrderRequest } from 'src/app/models/i.pizza-order-request';
import { IPizzaSize } from 'src/app/models/i.pizza-size';
import { PizzeriaConstants } from 'src/app/shared/constants/pizza-constants';
import { ConstituentsService } from 'src/app/shared/constituents.service';
import { PizzaOrderService } from 'src/app/shared/pizzaorder.service';

@Component({
  selector: 'app-bake-pizza',
  templateUrl: './bake-pizza.component.html',
  styleUrls: ['./bake-pizza.component.scss']
})
export class BakePizzaComponent implements OnInit {

  public customPizzaForm!: FormGroup;
  public pizzas: IPizza[] = [];
  public selectedPizza!: IPizza;
  public selectedConstituents: IConstituents[] = [];
  public sizes!: IPizzaSize[];
  public toppings!: IConstituents[];
  public crust!: IConstituents[];
  public sauce!: IConstituents[];
  public extraCheese!: IConstituents[];
  public previousNoPizza: number = 1;
  public currentNoPizza: number;
  public url: string;

  constructor(public formBuilder: FormBuilder,
    private constituentService: ConstituentsService,
    private pizzaOrderService: PizzaOrderService,
    public router: Router,
    private toasr: ToastrService) { }

  ngOnInit(): void {
    this.url = PizzeriaConstants.CustomePizzaUrl;
    this.createPizzaForm();
    this.getAllPizza();
    this.getAllCrust();
    this.getAllToppings();
    this.getSauce();
    this.getPizzaSizes();
    this.getExtraCheese();
  }

  public createPizzaForm(): void {
    this.customPizzaForm = this.formBuilder.group({
      pizzaId: [],
      numberOfPizza: ['', [Validators.required, Validators.pattern("^[0-9]*$")]],
      toppingId: [],
      sizeId: [],
      crustId: [],
      sauceId: [],
      isAddCheese: [false],
      isAddExtraCheese: [false]
    });
  }

  public getAllPizza(): void {
    this.pizzaOrderService.getAllPizza().subscribe((result) => {
      this.pizzas = result;
    });
  }

  public getSauce(): void {
    this.constituentService.getSauce().subscribe((result) => {
      this.sauce = result;
    });
  }

  public getExtraCheese(): void {
    this.constituentService.getExtraCheese().subscribe((result) => {
      this.extraCheese = result;
    });
  }

  public getAllToppings(): void {
    this.constituentService.getToppings().subscribe((result) => {
      this.toppings = result;
    });
  }

  public getAllCrust(): void {
    this.constituentService.getCrust().subscribe((result) => {
      this.crust = result;
    });
  }

  public getPizzaSizes(): void {
    this.constituentService.getPizzaSize().subscribe((result) => {
      this.sizes = result;
    });
  }

  public onNumberOfPizzaEvent($event: any): void {
    if (this.customPizzaForm.controls['numberOfPizza'].value && this.selectedPizza) {
      this.currentNoPizza = this.customPizzaForm.controls['numberOfPizza'].value;
      if(this.currentNoPizza > this.previousNoPizza) {
        this.selectedPizza.price = (this.selectedPizza.price / this.previousNoPizza) * this.currentNoPizza;
        this.previousNoPizza = this.currentNoPizza;
      } else if(this.currentNoPizza < this.previousNoPizza) {
        this.selectedPizza.price = (this.selectedPizza.price / this.previousNoPizza) * this.currentNoPizza;
        this.previousNoPizza = this.currentNoPizza;
      }
    }
  }


  public priceByConstituents(constituentId: number): void {
    if (constituentId) {
      this.constituentService.getConstituentById(constituentId).subscribe((result) => {
        if (result && this.selectedPizza) {
          this.selectedConstituents.push(result);
          this.selectedPizza.price = this.selectedPizza.price + result.price;
        }
      });
    }
  }

  public onPizzaSelectedEvent($event: any): void {
    if ($event && $event.target && $event.target.value) {
      const pizzaId = this.customPizzaForm.controls['pizzaId'].value;
      this.pizzaOrderService.getPizzaById(pizzaId).subscribe((result) => {
        if (result) {
          this.selectedPizza = result;
        }
      });
    }
  }

  public onSauceSelectedEvent($event: any): void {
    if (this.customPizzaForm.controls['sauceId'].value) {
      this.priceByConstituents(this.customPizzaForm.controls['sauceId'].value);
    }
  }

  public onToppingSelectedEvent($event: any): void {
    if (this.customPizzaForm.controls['toppingId'].value) {
      this.priceByConstituents(this.customPizzaForm.controls['toppingId'].value);
    }
  }

  public onCrustSelectedEvent($event: any): void {
    if (this.customPizzaForm.controls['crustId'].value) {
      this.priceByConstituents(this.customPizzaForm.controls['crustId'].value);
    }
  }

  public OnPizzaSizeSelectedEvent($event: any): void {
    if (this.customPizzaForm.controls['sizeId'].value && this.selectedPizza) {
      this.selectedPizza.price *= this.getMultiplerForSize(this.customPizzaForm.controls['sizeId'].value).id;
    }
  }

  private getMultiplerForSize(size: string): IPizzaSize {
    var pizzaSize = null;
    this.sizes.forEach(item => {
      if (item.name.toString() === size) {
        pizzaSize = item
      }
    });
    return pizzaSize;
  }

  public onAddCheeseChangeEvent($event: any): void {
    if (this.customPizzaForm.controls['isAddCheese'].value && this.selectedPizza) {
      this.selectedPizza.price = this.selectedPizza.price + PizzeriaConstants.CheeseConstant;
    } else if (!this.customPizzaForm.controls['isAddCheese'].value) {
      this.selectedPizza.price = this.selectedPizza.price - PizzeriaConstants.CheeseConstant;
    }

  }

  public onAddExtraCheeseChangeEvent($event: any): void {
    if (this.customPizzaForm.controls['isAddExtraCheese'].value && this.selectedPizza) {
      this.selectedPizza.price = this.selectedPizza.price + PizzeriaConstants.ExtraCheeseConstant;
    } else if (!this.customPizzaForm.controls['isAddExtraCheese'].value) {
      this.selectedPizza.price = this.selectedPizza.price - PizzeriaConstants.ExtraCheeseConstant;
    }
  }

  public onBakePizza() {
    const constituent = [];
    this.selectedConstituents.forEach(x => {
      constituent.push(x.id);
    });
    if (this.customPizzaForm.valid) {
      let request: IPizzaOrderRequest = {
        name: this.selectedPizza ? this.selectedPizza.name : '',
        isAddCheese: this.customPizzaForm.controls.isAddCheese.value,
        isAddExtraCheese: this.customPizzaForm.controls.isAddExtraCheese.value,
        numberOfPizza: this.customPizzaForm.controls.numberOfPizza.value,
        constituents: constituent,
        size: this.getMultiplerForSize(this.customPizzaForm.controls['sizeId'].value)?.id
      }

      if(this.selectedPizza.name === PizzeriaConstants.VeggieDhamaka) {
        this.pizzaOrderService.bakePizza(request, this.selectedPizza.id).subscribe(_ => {
          this.toasr.success(`Ordered Placed Successfully for ${this.selectedPizza.name}`);
          setTimeout(() => {
            this.router.navigate(['menu'])}, 6000);
        });
      } else if (this.selectedPizza.name === PizzeriaConstants.CustomizedPizza) {
        this.pizzaOrderService.bakeCustomizedPizza(request).subscribe(_ => {
          this.toasr.success(`Ordered Placed Successfully for ${this.selectedPizza.name}`);
          setTimeout(() => {
            this.router.navigate(['menu'])}, 6000);
        });
      }
    }
  }
}
