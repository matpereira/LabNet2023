import { Component } from '@angular/core';
export interface Customers {
  companyName: string;
  adress : string;
  phone: string;
  region: string;
}

const listCustomers: Customers[] = [
  {companyName: 'asd', adress: 'Hydrogen', phone:'1231234', region: 'ARG'},
  {companyName: 'asd', adress: 'Helium', phone:'1231234', region: 'ARG'},
  {companyName: 'asd', adress: 'Lithium', phone:'1231234', region: 'ARG'},
  {companyName: 'asd', adress: 'Beryllium', phone:'1231234', region: 'ARG'},
  {companyName: 'asd', adress: 'Boron', phone:'1231234', region: 'ARG'},
  {companyName: 'asd', adress: 'Carbon', phone:'1231234', region: 'ARG'},

];

@Component({
  selector: 'app-customers',
  templateUrl: './customers.component.html',
  styleUrls: ['./customers.component.css']
})
export class CustomersComponent {
  displayedColumns: string[] = ['companyName', 'adress', 'phone', 'region'];
  dataSource = listCustomers;
}
