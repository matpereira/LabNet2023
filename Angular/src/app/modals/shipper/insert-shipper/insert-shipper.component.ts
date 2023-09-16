import { Component, EventEmitter, Output } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { ValidationService } from 'src/app/components/service/validation.service';
import Swal from 'sweetalert2';

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
    private validationService: ValidationService
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
  
    // Verificar si el teléfono no es nulo y no es válido
    if (phoneValue && !this.validationService.validatePhoneNumber(phoneValue)) {
      // Mostrar un mensaje de error con SweetAlert
      Swal.fire('Error', 'El número de teléfono no es válido.', 'error');
      return; // Detener el envío del formulario si el teléfono no es válido
    }
  
    // Datos válidos, emitir los datos al componente principal
    this.shipperAdded.emit(this.form.value);
  
    // Cerrar el modal
    this.closeDialog();
  
    // Mostrar Sweet Alert de éxito
    Swal.fire('Éxito', 'El shipper ha sido agregado con éxito.', 'success');
  
    // Recargar la página actual después de un breve retraso
    setTimeout(() => {
      window.location.reload();
    }, 2000); // Espera 2 segundos antes de recargar la página
  }

  // Método para cerrar el modal
  closeDialog() {
    this.form.reset(); // Reiniciar el formulario
  }
}