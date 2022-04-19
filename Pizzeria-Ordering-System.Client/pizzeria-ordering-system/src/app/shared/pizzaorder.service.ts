import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
import { environment } from 'src/environments/environment';
import { IPizza } from '../models/i.pizza';
import { IPizzaOrderRequest } from '../models/i.pizza-order-request';


@Injectable({
  providedIn: 'root'
})
export class PizzaOrderService {

  constructor(private httpClient: HttpClient) { }

  public getAllPizza(): Observable<IPizza[]> {
    const url = environment.server_url + 'api/v1/pizza/getAll';
    return this.httpClient.get<IPizza[]>(url);
  }

  public getPizzaById(pizzaId: number): Observable<IPizza> {
    const url = environment.server_url + `api/v1/pizza/${pizzaId}`;
    return this.httpClient.get<IPizza>(url);
  }

  public bakeCustomizedPizza(request: IPizzaOrderRequest): Observable<any> {
    const url = environment.server_url + 'api/v1/pizza/customPizza';
    return this.httpClient.post<any>(url, request);
  }

  public bakePizza(request: IPizzaOrderRequest, pizzaId: number): Observable<any> {
    const url = environment.server_url + `api/v1/pizza/avlblPizza/${pizzaId}`;
    return this.httpClient.post<any>(url, request);
  }

}
