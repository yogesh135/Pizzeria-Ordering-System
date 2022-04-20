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
import { ToastrModule } from 'ngx-toastr';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';


@NgModule({
  declarations: [
    AppComponent,
    MenuComponent,
    BakePizzaComponent,
    HeaderComponent
  ],
  imports: [
    BrowserModule,
    BrowserAnimationsModule,
    HttpClientModule,
    AppRoutingModule,
    CommonModule,
    FlexLayoutModule,
    ReactiveFormsModule,
    ToastrModule.forRoot({
      timeOut:5000,
      preventDuplicates: true,
      enableHtml: true
    })
  ],
  providers: [PizzaOrderService, ConstituentsService],
  bootstrap: [AppComponent]
})
export class AppModule { }
