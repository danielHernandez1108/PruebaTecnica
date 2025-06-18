import { Component, inject } from '@angular/core';
import { ActivatedRoute, Router, RouterOutlet } from '@angular/router';
import { ConsultOrders } from './Shared/Services/ConsultOrders.service';
import { Orders } from './Shared/models/Orders.model';
import { NgFor, NgIf } from '@angular/common';

@Component({
  selector: 'app-root',
  imports: [RouterOutlet, NgIf, NgFor],
  templateUrl: './app.component.html',
  styleUrl: './app.component.css'

})
export class AppComponent {
  public service = inject(ConsultOrders);
  public router = inject(Router);
  public activatedRoute = inject(ActivatedRoute);
  public Order: Orders[] = [];


  ngOnInit(): void {
    this.loadPatients();

  }

  private loadPatients() {
    this.service.ConsultOrders().subscribe({
      next: (data) => {
        console.log('Respuesta:', data);
        this.Order = data.data;
        console.log(this.Order);
      },
      error: (err) => {
        console.error('Error al consultar órdenes:', err);
      }
    });
  }
}
