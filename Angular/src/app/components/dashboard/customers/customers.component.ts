import { Component, ViewChild, AfterViewInit, OnInit } from '@angular/core';
import { MatPaginator } from '@angular/material/paginator';
import { MatSort } from '@angular/material/sort';
import { MatTableDataSource } from '@angular/material/table';
import { Customers } from '../../core/models/Customers_model';
import { MatDialog } from '@angular/material/dialog';
import Swal from 'sweetalert2';
import { CustomerServiceService } from '../../service/customer.service';
import { EditCustomerComponent } from 'src/app/modals/customer/edit-customer/edit-customer.component';
import { InsertCustomerComponent } from 'src/app/modals/customer/insert-customer/insert-customer.component';

@Component({
  selector: 'app-customers',
  templateUrl: './customers.component.html',
  styleUrls: ['./customers.component.css']
})

export class CustomersComponent implements OnInit, AfterViewInit {
  displayedColumns: string[] = ['CustomerID', 'CompanyName', 'Phone', 'Address','Region','Edit', 'Delete'];
  filterValue: string = '';
  selectedFilter: string = 'all';
  listCustomers: Customers[] = [];
  dataSource = new MatTableDataSource<Customers>();

  constructor(private customerService: CustomerServiceService, private dialog: MatDialog) {}

  @ViewChild(MatPaginator) paginator!: MatPaginator;
  @ViewChild(MatSort) sort!: MatSort;

  ngOnInit(): void {
    this.getAllCustomers();
  }

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


  //get all
  getAllCustomers() {
    try {
      this.customerService.getAllCustomers().subscribe((res: any) => {
        this.listCustomers = res;
        this.dataSource.data = this.listCustomers;
      });
    } catch (error) {
      console.log(error);
    }
  }

//delete
deleteCustomer(customerId: string) {
  Swal.fire({
    title: '¿Estás seguro?',
    text: 'Esta acción no se puede deshacer',
    icon: 'warning',
    showCancelButton: true,
    confirmButtonText: 'Sí, eliminar',
    cancelButtonText: 'Cancelar',
  }).then((result) => {
    if (result.value) {
      // El usuario confirmó la eliminación, realiza la solicitud DELETE
      this.customerService.deleteCustomer(customerId).subscribe(
        () => {
          // La eliminación se realizó con éxito, puedes actualizar la lista o realizar otras acciones.
          this.getAllCustomers();
          Swal.fire('Eliminado', 'El customer ha sido eliminado', 'success');
        },
        (error) => {
          console.error('Error al eliminar el customer:', error);
          // Captura y maneja el error aquí
          Swal.fire('Error', 'Hubo un problema al eliminar el customer', 'error');
        }
      );
    }
  });
}

//insert aqui
insertCustomer() {
  const dialogRef = this.dialog.open(InsertCustomerComponent, {
    width: '400px',
  });

  dialogRef.componentInstance.customerAdded.subscribe((result) => {
    if (result) {
      console.log('Datos recibidos:', result);
      this.customerService.addCustomer(result).subscribe(
        (response) => {
          console.log('Customer agregado con éxito:', response);
          this.getAllCustomers();
        },
        (error) => {
          console.error('Error al agregar el customer:', error);
          Swal.fire('Error', 'Hubo un problema al agregar el customer', 'error');
        }
      );
    }
  });
}

updateCustomer(customer: Customers) {
  const dialogRef = this.dialog.open(EditCustomerComponent, {
    width: '400px',
    data: { customer }, // Pasa los datos del customer al modal
  });

  dialogRef.componentInstance.customerUpdated.subscribe((result) => {
    if (result) {
      // Agrega el id del customer que deseas editar a los datos actualizados

      result.CustomerId = customer.CustomerID;

      this.customerService.updateCustomer(result.CustomerId, result.customerData).subscribe(
        (response) => {
          console.log('Customer modificado con éxito:', response);
          this.getAllCustomers();
        },
        (error) => {
          console.error('Error al modificar el customer:', error);
          Swal.fire('Error', 'Hubo un problema al modificar el customer', 'error');
        }
      );
    }
  });
}



}