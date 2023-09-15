import { Component } from '@angular/core';

export interface Shippers {
  companyName: string;
  phone: string;
}

const listShippers: Shippers[] = [
  {companyName: 'asd', phone: '12345678'},
  {companyName: 'asd', phone: '12345678'},
  {companyName: 'asd', phone: '12345678'},
  {companyName: 'asd', phone: '12345678'},
  {companyName: 'asd', phone: '12345678'},
  {companyName: 'asd', phone: '12345678'},
  {companyName: 'asd', phone: '12345678'},
  {companyName: 'asd', phone: '12345678'},

];

@Component({
  selector: 'app-shippers',
  templateUrl: './shippers.component.html',
  styleUrls: ['./shippers.component.css']
})
export class ShippersComponent {
  displayedColumns: string[] = ['companyName', 'phone'];
  dataSource = listShippers;
}
