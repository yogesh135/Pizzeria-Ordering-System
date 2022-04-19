import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';

import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { MenuComponent } from './component/menu/menu.component';
import { BakePizzaComponent } from './component/bake-pizza/bake-pizza.component';
import { HeaderComponent } from './component/header/header.component';
import { HttpClientModule } from '@angular/common/http';
import { CommonModule } from '@angular/common';
import { PizzaOrderService } from './shared/pizzaorder.service';
import { ConstituentsService } from './shared/constituents.service';
import { FlexLayoutModule } from '@angular/flex-layout';
import { ReactiveFormsModule } from '@angular/forms';


@NgModule({
  declarations: [
    AppComponent,
    MenuComponent,
    BakePizzaComponent,
    HeaderComponent
  ],
  imports: [
    BrowserModule,
    HttpClientModule,
    AppRoutingModule,
    CommonModule,
    FlexLayoutModule,
    ReactiveFormsModule,
  ],
  providers: [PizzaOrderService, ConstituentsService],
  bootstrap: [AppComponent]
})
export class AppModule { }
