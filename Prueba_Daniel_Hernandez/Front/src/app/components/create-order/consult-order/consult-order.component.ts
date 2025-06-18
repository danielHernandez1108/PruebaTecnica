import { Component, inject } from '@angular/core';
import { ConsultOrders } from '../../../Shared/Services/ConsultOrders.service';
import { Router } from 'express';
import { ActivatedRoute, } from '@angular/router';
import { CommonModule } from '@angular/common';

import { first, zip } from 'rxjs';
import { FormBuilder, FormControl, FormGroup, ReactiveFormsModule, Validators } from '@angular/forms';
import { Orders } from '../../../Shared/models/Orders.model';
@Component({
  selector: 'app-consult-order',
  imports: [
    CommonModule,
    ReactiveFormsModule
  ],
  standalone: true,
  templateUrl: './consult-order.component.html',
  styleUrl: './consult-order.component.css'
})
export class ConsultOrderComponent {

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
        this.Order = data.Data;
      },
      error: (err) => {
        console.error('Error al consultar órdenes:', err);
      }
    });
  }

}
