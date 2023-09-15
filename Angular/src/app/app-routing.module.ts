import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { ShippersComponent } from './components/shippers/shippers.component';
import { HomeComponent } from './components/home/home.component';
import { CustomersComponent } from './components/customers/customers.component';

const routes: Routes = [
  { path: 'home', component: HomeComponent },
  { path: 'shippers', component: ShippersComponent },
  { path: 'customers', component: CustomersComponent }, 
  { path: '', redirectTo: '/home', pathMatch: 'full' },
  { path: '**', component: HomeComponent}
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
