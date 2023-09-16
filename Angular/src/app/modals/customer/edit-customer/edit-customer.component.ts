import { Component, Inject } from '@angular/core';
import { MatDialogRef, MAT_DIALOG_DATA } from '@angular/material/dialog';


@Component({
  selector: 'app-edit-customer',
  templateUrl: './edit-customer.component.html',
})
export class EditCustomerComponent {
  constructor(
    public dialogRef: MatDialogRef<EditCustomerComponent>,
    @Inject(MAT_DIALOG_DATA) public data: any
  ) {}

  saveChanges() {
    // Procesa los cambios y devuelve los datos actualizados al componente principal
    const updatedData = {
      // ... Actualiza los datos según el formulario de edición
    };

    this.dialogRef.close(updatedData);
  }

  closeDialog() {
    this.dialogRef.close();
  }

  
}
