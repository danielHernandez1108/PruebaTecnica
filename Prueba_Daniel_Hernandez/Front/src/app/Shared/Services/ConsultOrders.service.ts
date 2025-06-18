import { HttpClient } from '@angular/common/http';
import { Injectable, inject } from '@angular/core';
import { Orders } from '../models/Orders.model';
import { Observable } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class ConsultOrders {

  private readonly url = "https://localhost:7294/api";
  private http: HttpClient = inject(HttpClient);

  public ConsultOrders(): Observable<any> {
    return this.http.get<any>(`${this.url}/ConsultOrder`);
  }
}
