import { Component, OnInit, ViewChild } from '@angular/core';
import { MatPaginator } from '@angular/material/paginator';
import { MatSort } from '@angular/material/sort';
import { MatTableDataSource } from '@angular/material/table';
import { EditCustomerComponent } from 'src/app/modals/customer/edit-customer/edit-customer.component';
import { MatDialog } from '@angular/material/dialog';
import Swal from 'sweetalert2';


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
  displayedColumns: string[] = ['companyName', 'adress', 'phone', 'region', 'edit', 'delete'];
  dataSource = new MatTableDataSource(listCustomers);
  filterValue: string = ''; // Propiedad para almacenar el valor del filtro
  selectedFilter: string = 'all'; // Propiedad para almacenar la opción de filtro seleccionada
  @ViewChild(MatPaginator) paginator!: MatPaginator;
  @ViewChild(MatSort) sort!: MatSort;

  constructor(private dialog: MatDialog ) {}
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

  editCustomer(customer: Customers) {
    const dialogRef = this.dialog.open(EditCustomerComponent, {
      width: '40%' , // Ancho del modal
      height: 'auto', // Alto del modal
      data: { customer }, // Pasa los datos del transportista al modal
    });
  
    dialogRef.afterClosed().subscribe(() => {
    });
  }

    deleteCustomer(customerId: number) {
    }

}
