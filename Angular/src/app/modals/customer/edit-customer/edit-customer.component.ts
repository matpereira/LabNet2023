import { Component, EventEmitter, Inject, Output } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { MAT_DIALOG_DATA, MatDialogRef } from '@angular/material/dialog';
import { Customers } from 'src/app/components/core/models/Customers_model';
import Swal from 'sweetalert2';
import { ValidationService } from 'src/app/components/service/validation.service';

@Component({
  selector: 'app-edit-customer',
  templateUrl: './edit-customer.component.html',
  styleUrls: ['./edit-customer.component.css'],
})
export class EditCustomerComponent {
  @Output() customerUpdated = new EventEmitter<any>();
  form: FormGroup;

  constructor(
    private fb: FormBuilder,
    private dialogRef: MatDialogRef<EditCustomerComponent>,
    @Inject(MAT_DIALOG_DATA) public data: { customer: Customers },
    private validationService: ValidationService 
  ) {
    this.form = this.fb.group({
      companyName: [data.customer.CompanyName, [Validators.required, Validators.maxLength(40)]],
      phone: [data.customer.Phone],
      address: [data.customer.address],
    });
  }

  saveChanges() {
    const companyNameValue = this.form.get('companyName')?.value;
    const phoneValue = this.form.get('phone')?.value;
    const addressValue = this.form.get('address')?.value;
  
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

    if (addressValue && addressValue.length > 60) {
      Swal.fire('Error', 'La dirección no puede tener más de 60 caracteres.', 'error');
      return;
    }

    const updatedCustomerData = {
      customerId: this.data.customer.CustomerID,
      customerData: this.form.value,
    };

    console.log(updatedCustomerData);
    this.customerUpdated.emit(updatedCustomerData);
    this.closeDialog();
  }

  closeDialog() {
    this.dialogRef.close();
  }
}
