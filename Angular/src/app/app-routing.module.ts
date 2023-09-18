import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { ShippersComponent } from './components/dashboard/shippers/shippers.component';
import { CustomersComponent } from './components/dashboard/customers/customers.component';

const routes: Routes = [
  { path: 'shippers', component: ShippersComponent },
  { path: 'customers', component: CustomersComponent }, 
  { path: '', redirectTo: '/shippers', pathMatch: 'full' },
  { path: '**',component: ShippersComponent }
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
