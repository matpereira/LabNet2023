import { Component, EventEmitter, Inject, Output } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { MAT_DIALOG_DATA, MatDialogRef } from '@angular/material/dialog';
import { Shippers } from 'src/app/components/core/models/Shippers_model';
import { ValidationService } from 'src/app/components/service/validation.service';

@Component({
  selector: 'app-edit-shipper',
  templateUrl: './edit-shipper.component.html',
  styleUrls: ['./edit-shipper.component.css'],
})
export class EditShipperComponent {
  @Output() shipperUpdated = new EventEmitter<any>();
  form: FormGroup;

  constructor(
    private fb: FormBuilder,
    private dialogRef: MatDialogRef<EditShipperComponent>,
    @Inject(MAT_DIALOG_DATA) public data: { shipper: Shippers } 
  ) {
    this.form = this.fb.group({
      companyName: [data.shipper.CompanyName, [Validators.required, Validators.maxLength(40)]],
      phone: [data.shipper.Phone],
    });
  }

  saveChanges() {
    if (this.form.valid) {

      const updatedShipperData = {
        shipperId: this.data.shipper.ShipperID,
        shipperData: this.form.value,
      };
      this.shipperUpdated.emit(updatedShipperData);
      this.closeDialog();
    }
  }

  closeDialog() {
    this.dialogRef.close(); // Cierra el modal usando MatDialogRef
  }
}