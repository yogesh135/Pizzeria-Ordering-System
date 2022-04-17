import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import { BakePizzaComponent } from './component/bake-pizza/bake-pizza.component';
import { MenuComponent } from './component/menu/menu.component';

const routes: Routes = [
  { path: 'menu', component: MenuComponent },
  { path: 'bake-pizza', component: BakePizzaComponent},
  { path: '', redirectTo: '/menu', pathMatch: 'full'}
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
