import { Component, OnInit, ViewChild } from '@angular/core';
import { MatPaginator } from '@angular/material/paginator';
import { MatSort } from '@angular/material/sort';
import { MatTableDataSource } from '@angular/material/table';

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
export class CustomersComponent implements OnInit {
  displayedColumns: string[] = ['companyName', 'adress', 'phone', 'region','actions'];
  dataSource = new MatTableDataSource(listCustomers);
  filterValue: string = ''; // Propiedad para almacenar el valor del filtro
  selectedFilter: string = 'all'; // Propiedad para almacenar la opción de filtro seleccionada
  @ViewChild(MatPaginator) paginator!: MatPaginator;
  @ViewChild(MatSort) sort!: MatSort;

  constructor() {}
  ngOnInit(): void {}

  ngAfterViewInit() {
    this.dataSource.paginator = this.paginator;
   this.dataSource.sort = this.sort;
  }
  
  applyFilter() {
    if (this.selectedFilter === 'all') {
      this.dataSource.filter = '';
    } else {
      this.dataSource.filter = this.filterValue.trim().toLowerCase();
    }
  }

  editCustomer(companyName : string) {
    console.log('edit');
  }

  deleteCustomer(companyName : string) {
    console.log('delete');
  }
}
