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
    const route = environment.server_url + 'api/v1/constituents/getAll';
    return this.httpClient.get<IConstituents[]>(route);

  }
  public getToppings():  Observable<IConstituents[]> {
    const route = environment.server_url + 'api/v1/constituents/toppings';
    return this.httpClient.get<IConstituents[]>(route);

  }

  public getCrust():  Observable<IConstituents[]> {
    const route = environment.server_url + 'api/v1/constituents/crust';
    return this.httpClient.get<IConstituents[]>(route);

  }

  public getSauce():  Observable<IConstituents[]> {
    const route = environment.server_url + 'api/v1/constituents/sauce';
    return this.httpClient.get<IConstituents[]>(route);

  }

  public getExtraCheese():  Observable<IConstituents[]> {
    const route = environment.server_url + 'api/v1/constituents/extraCheese';
    return this.httpClient.get<IConstituents[]>(route);
    
  }

  public getPizzaSize():  Observable<IPizzaSize[]> {
    const route = environment.server_url + 'api/v1/constituents/size';
    return this.httpClient.get<IPizzaSize[]>(route);

  }
  public getConstituentById(constituentId: number): Observable<IConstituents> {
    const route = environment.server_url + `api/v1/constituents/${constituentId}`;
    return this.httpClient.get<IConstituents>(route);

  }

  public getAllConstituentsType(): Observable<IConstituentsType> {
    const route = environment.server_url + 'api/v1/constituents/types';
    return this.httpClient.get<IConstituentsType>(route);

  }

  public getConstituentType(typeId: number): Observable<IConstituents> {
    const route = environment.server_url + `api/v1/constituents/types/${typeId}`;
    return this.httpClient.get<IConstituents>(route);
    
  }
}
