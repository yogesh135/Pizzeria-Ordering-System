import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { environment } from 'src/environments/environment';
import { IConstituents } from '../models/i.constituents';
import { IConstituentsType } from '../models/i.constituents-type';
import { IPizzaSize } from '../models/i.pizza-size';

@Injectable({
  providedIn: 'root'
})
export class ConstituentsService {

  constructor(private httpClient: HttpClient) { }

  public getAllConstituents():  Observable<IConstituents[]> {
    const url = environment.server_url + 'api/v1/constituents/getAll';
    return this.httpClient.get<IConstituents[]>(url);

  }
  public getToppings():  Observable<IConstituents[]> {
    const url = environment.server_url + 'api/v1/constituents/toppings';
    return this.httpClient.get<IConstituents[]>(url);

  }

  public getCrust():  Observable<IConstituents[]> {
    const url = environment.server_url + 'api/v1/constituents/crust';
    return this.httpClient.get<IConstituents[]>(url);

  }

  public getSauce():  Observable<IConstituents[]> {
    const url = environment.server_url + 'api/v1/constituents/sauce';
    return this.httpClient.get<IConstituents[]>(url);

  }

  public getExtraCheese():  Observable<IConstituents[]> {
    const url = environment.server_url + 'api/v1/constituents/extraCheese';
    return this.httpClient.get<IConstituents[]>(url);
    
  }

  public getPizzaSize():  Observable<IPizzaSize[]> {
    const url = environment.server_url + 'api/v1/constituents/size';
    return this.httpClient.get<IPizzaSize[]>(url);

  }
  public getConstituentById(constituentId: number): Observable<IConstituents> {
    const url = environment.server_url + `api/v1/constituents/${constituentId}`;
    return this.httpClient.get<IConstituents>(url);

  }

  public getAllConstituentsType(): Observable<IConstituentsType> {
    const url = environment.server_url + 'api/v1/constituents/types';
    return this.httpClient.get<IConstituentsType>(url);

  }

  public getConstituentType(typeId: number): Observable<IConstituents> {
    const url = environment.server_url + `api/v1/constituents/types/${typeId}`;
    return this.httpClient.get<IConstituents>(url);

  }
}
