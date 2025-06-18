import { Routes } from '@angular/router';

export const routes: Routes = [
  {
    path: 'consult-order',
    loadComponent: () =>
      import('./components/create-order/consult-order/consult-order.component')
        .then(m => m.ConsultOrderComponent)
  }
];
