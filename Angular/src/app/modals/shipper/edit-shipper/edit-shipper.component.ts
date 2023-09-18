import { Component, EventEmitter, Inject, Output } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { MAT_DIALOG_DATA, MatDialogRef } from '@angular/material/dialog';
import { Shippers } from 'src/app/components/core/models/Shippers_model';
import Swal from 'sweetalert2';
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
    @Inject(MAT_DIALOG_DATA) public data: { shipper: Shippers },
    private validationService: ValidationService // Agrega el servicio de validación
  ) {
    this.form = this.fb.group({
      companyName: [data.shipper.CompanyName, [Validators.required, Validators.maxLength(40)]],
      phone: [data.shipper.Phone],
    });
  }

  saveChanges() {
    const companyNameValue = this.form.get('companyName')?.value;
    const phoneValue = this.form.get('phone')?.value;
  
    if (!companyNameValue.trim()) {
      Swal.fire('Error', 'El nombre de la compañía no puede estar vacío.', 'error');
      return;
    }
  
    if (companyNameValue.length > 40) {
      Swal.fire('Error', 'El nombre de la compañía no puede tener más de 40 caracteres.', 'error');
      return;
    }
  
    if (phoneValue && !this.validationService.validatePhoneNumber(phoneValue)) {
      Swal.fire('Error', 'El número de teléfono no es válido.', 'error');
      return; 
    }

    const updatedShipperData = {
      shipperId: this.data.shipper.ShipperID,
      shipperData: this.form.value,
    };
    this.shipperUpdated.emit(updatedShipperData);
    this.closeDialog();
  }

  closeDialog() {
    this.dialogRef.close();
  }
}
