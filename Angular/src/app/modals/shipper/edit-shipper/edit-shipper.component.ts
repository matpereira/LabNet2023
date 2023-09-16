import { ValidationService } from 'src/app/components/service/validation.service';
import { Component, Inject } from '@angular/core';
import { MatDialogRef, MAT_DIALOG_DATA } from '@angular/material/dialog';
import { FormBuilder, FormGroup, Validators, AbstractControl } from '@angular/forms'; // Importa FormBuilder y FormGroup

@Component({
  selector: 'app-edit-shipper',
  templateUrl: './edit-shipper.component.html',
})
export class EditShipperComponent {
  form: FormGroup;

  constructor(
    public dialogRef: MatDialogRef<EditShipperComponent>,
    @Inject(MAT_DIALOG_DATA) public data: any,
    private fb: FormBuilder,
    private validationService: ValidationService // Inyecta el servicio de validación
  ) {
    this.form = this.fb.group({
      companyName: [
        data.shipper.companyName,
        [
          Validators.required,
          Validators.maxLength(40),
          (control: AbstractControl) => this.customCompanyNameValidator(control), // Declara el tipo de 'control' aquí
        ],
      ],
      phone: [
        data.shipper.phone,
        [
          Validators.required,
          Validators.pattern(
            /^(?=\(?\+?\d{1,3}\)?)(?=.{1,24}$)\(?\+?\d{1,3}\)?[\s-]?\d{1,24}$/
          ),
        ],
        (control: AbstractControl) => this.customPhoneValidator(control), // Declara el tipo de 'control' aquí
      ],
    });
  }

  customCompanyNameValidator(
    control: AbstractControl
  ): { [key: string]: boolean } | null {
    const isValid = this.validationService.validateCompanyNameLength(
      control.value,
      40
    );

    return isValid ? null : { invalidCompanyNameLength: true };
  }

  customPhoneValidator(control: AbstractControl): { [key: string]: boolean } | null {
    const isValid = this.validationService.validatePhoneNumber(control.value);

    return isValid ? null : { invalidPhone: true };
  }

  saveChanges() {
    console.log('Botón "Guardar" clicado');
    if (this.form.valid) {
      const updatedData = this.form.value;
      this.dialogRef.close(updatedData);
    }
  }

  closeDialog() {
    this.dialogRef.close();
  }
}
