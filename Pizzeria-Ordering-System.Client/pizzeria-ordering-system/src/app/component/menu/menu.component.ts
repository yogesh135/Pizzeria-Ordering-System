import { Component, OnInit } from '@angular/core';
import { IPizza } from 'src/app/models/i.pizza';
import { ISideBeverages } from 'src/app/models/i.side-beverages';
import { PizzaOrderService } from 'src/app/shared/pizzaorder.service';

@Component({
  selector: 'app-menu',
  templateUrl: './menu.component.html',
  styleUrls: ['./menu.component.scss']
})
export class MenuComponent implements OnInit {

  public pizzas : IPizza[] = [];
  public sideBeverages : ISideBeverages[] = [];
  constructor(private pizzaOrderService: PizzaOrderService) { }

  ngOnInit(): void {
    this.pizzaOrderService.getAllPizza().subscribe(item => {
      this.pizzas = item;
    });

    this.pizzaOrderService.getAllSideBeverages().subscribe(item => {
      this.sideBeverages = item;
    })
  }

}
