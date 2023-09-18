import { Component, EventEmitter, Output } from '@angular/core';
import { FormBuilder, FormGroup, Validators, FormControl } from '@angular/forms';
import { ValidationService } from 'src/app/components/service/validation.service';
import Swal from 'sweetalert2';
import { MatDialogRef } from '@angular/material/dialog'; 

@Component({
  selector: 'app-insert-customer',
  templateUrl: './insert-customer.component.html',
  styleUrls: ['./insert-customer.component.css'],
})
export class InsertCustomerComponent {
  @Output() customerAdded = new EventEmitter<any>();
  form: FormGroup;

  constructor(
    private fb: FormBuilder,
    private validationService: ValidationService,
    public dialogRef: MatDialogRef<InsertCustomerComponent> 
  ) {
    this.form = this.fb.group({
      customerID: ['', [Validators.required, Validators.maxLength(5)]], 
      companyName: ['', [Validators.required, Validators.maxLength(40)]],
      phone: [''],
    });
  }

  saveChanges() {
    const customerIDValue = this.form.get('customerID')?.value;
    const companyNameValue = this.form.get('companyName')?.value;
    const phoneValue = this.form.get('phone')?.value;
  
    this.transformCustomerIDToUppercase(); // Llama a la función de transformación
  
if (!customerIDValue.trim()) {
      Swal.fire('Error', 'El ID del cliente no puede estar vacío.', 'error');
      return;
    }
  
    if(customerIDValue.length != 5){
      Swal.fire('Error', 'El ID del cliente debe tener 5 caracteres.', 'error');
      return;
    }

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
  
    console.log('Datos emitidos:', this.form.value);
    this.customerAdded.emit(this.form.value);
    this.closeDialog();
    Swal.fire('Éxito', 'El customer ha sido agregado con éxito.', 'success');
  }

  closeDialog() {
    this.dialogRef.close(); 
  }

  transformCustomerIDToUppercase() {
    const customerIDControl = this.form.get('customerID');
    if (customerIDControl) {
      customerIDControl.setValue(customerIDControl.value.toUpperCase());
    }
  }

}
