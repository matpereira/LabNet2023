import { Component, EventEmitter, Output } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { ValidationService } from 'src/app/components/service/validation.service';
import Swal from 'sweetalert2';
import { MatDialogRef } from '@angular/material/dialog'; // Importa MatDialogRef

@Component({
  selector: 'app-insert-shipper',
  templateUrl: './insert-shipper.component.html',
  styleUrls: ['./insert-shipper.component.css'],
})
export class InsertShipperComponent {
  @Output() shipperAdded = new EventEmitter<any>();
  form: FormGroup;

  constructor(
    private fb: FormBuilder,
    private validationService: ValidationService,
    public dialogRef: MatDialogRef<InsertShipperComponent> // Inyecta MatDialogRef
  ) {
    this.form = this.fb.group({
      companyName: ['', [Validators.required, Validators.maxLength(40)]],
      phone: [''],
    });
  }

  saveChanges() {
    const companyNameValue = this.form.get('companyName')?.value;
    const phoneValue = this.form.get('phone')?.value;
  
    // Verificar si el nombre de la compañía está vacío o tiene más de 40 caracteres
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
    this.shipperAdded.emit(this.form.value);
    this.closeDialog();
    Swal.fire('Éxito', 'El shipper ha sido agregado con éxito.', 'success');
  }

  // Método para cerrar el modal
  closeDialog() {
    this.dialogRef.close(); // Cierra el modal usando MatDialogRef
  }
}
