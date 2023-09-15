import { Component } from '@angular/core';

export interface Customers {
  companyName: string;
  adress: string;
  phone: string;
  region: string;
}

const listCustomers: Customers[] = [
  { companyName: 'asd', adress: 'Hydrogen', phone: '1231234', region: 'ARG' },
  { companyName: 'asd', adress: 'Helium', phone: '1231234', region: 'ARG' },
  { companyName: 'asd', adress: 'Lithium', phone: '1231234', region: 'ARG' },
  { companyName: 'asd', adress: 'Beryllium', phone: '1231234', region: 'ARG' },
  { companyName: 'asd', adress: 'Boron', phone: '1231234', region: 'ARG' },
  { companyName: 'asd', adress: 'Carbon', phone: '1231234', region: 'ARG' },
];

@Component({
  selector: 'app-customers',
  templateUrl: './customers.component.html',
  styleUrls: ['./customers.component.css']
})
export class CustomersComponent {
  displayedColumns: string[] = ['companyName', 'adress', 'phone', 'region'];
  dataSource = listCustomers;
  filterValue: string = ''; // Propiedad para almacenar el valor del filtro
  selectedFilter: string = 'all'; // Propiedad para almacenar la opción de filtro seleccionada

  applyFilter(): void {
    if (this.selectedFilter === 'all') {
      this.dataSource = listCustomers;
    } else {
      this.dataSource = listCustomers.filter(item =>
        item[this.selectedFilter as keyof Customers].toLowerCase().includes(this.filterValue.toLowerCase())
      );
    }
  }
}
