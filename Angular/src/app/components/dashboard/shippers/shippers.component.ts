import { Component, ViewChild, AfterViewInit, OnInit } from '@angular/core';
import { MatPaginator } from '@angular/material/paginator';
import { MatSort } from '@angular/material/sort';
import { MatTableDataSource } from '@angular/material/table';
import { Shippers } from '../../core/models/Shippers_model';
import { MatDialog } from '@angular/material/dialog';
import Swal from 'sweetalert2';
import { ShipperServiceService } from '../../service/shipper.service';
import { EditShipperComponent } from 'src/app/modals/shipper/edit-shipper/edit-shipper.component';
import { InsertShipperComponent } from 'src/app/modals/shipper/insert-shipper/insert-shipper.component';

@Component({
  selector: 'app-shippers',
  templateUrl: './shippers.component.html',
  styleUrls: ['./shippers.component.css']
})

export class ShippersComponent implements OnInit, AfterViewInit {
  displayedColumns: string[] = ['ShipperID', 'CompanyName', 'Phone', 'Edit', 'Delete'];
  filterValue: string = '';
  selectedFilter: string = 'all';
  listShippers: Shippers[] = [];
  dataSource = new MatTableDataSource<Shippers>();

  constructor(private shipperService: ShipperServiceService, private dialog: MatDialog) {}

  @ViewChild(MatPaginator) paginator!: MatPaginator;
  @ViewChild(MatSort) sort!: MatSort;

  ngOnInit(): void {
    this.getAllShippers();
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
  getAllShippers() {
    try {
      this.shipperService.getAllShippers().subscribe((res: any) => {
        this.listShippers = res;
        this.dataSource.data = this.listShippers;
      });
    } catch (error) {
      console.log(error);
    }
  }

//delete
deleteShipper(shipperId: number) {
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
      this.shipperService.deleteShipper(shipperId).subscribe(
        () => {
          // La eliminación se realizó con éxito, puedes actualizar la lista o realizar otras acciones.
          this.getAllShippers();
          Swal.fire('Eliminado', 'El shipper ha sido eliminado', 'success');
        },
        (error) => {
          console.error('Error al eliminar el shipper:', error);
          // Captura y maneja el error aquí
          Swal.fire('Error', 'Hubo un problema al eliminar el shipper', 'error');
        }
      );
    }
  });
}

//insert aqui
insertShipper() {
  const dialogRef = this.dialog.open(InsertShipperComponent, {
    width: '400px',
  });

  dialogRef.componentInstance.shipperAdded.subscribe((result) => {
    if (result) {
      console.log('Datos recibidos:', result);
      this.shipperService.addShipper(result).subscribe(
        (response) => {
          console.log('Shipper agregado con éxito:', response);
          this.getAllShippers();
        },
        (error) => {
          console.error('Error al agregar el shipper:', error);
          Swal.fire('Error', 'Hubo un problema al agregar el shipper', 'error');
        }
      );
    }
  });
}

updateShipper(shipper: Shippers) {
  const dialogRef = this.dialog.open(EditShipperComponent, {
    width: '400px',
    data: { shipper }, // Pasa los datos del shipper al modal
  });

  dialogRef.componentInstance.shipperUpdated.subscribe((result) => {
    if (result) {
      // Agrega el id del shipper que deseas editar a los datos actualizados
      result.shipperId = shipper.ShipperID;

      this.shipperService.updateShipper(result.shipperId, result.shipperData).subscribe(
        (response) => {
          console.log('Shipper modificado con éxito:', response);
          this.getAllShippers();
        },
        (error) => {
          console.error('Error al modificar el shipper:', error);
          Swal.fire('Error', 'Hubo un problema al modificar el shipper', 'error');
        }
      );
    }
  });
}



}