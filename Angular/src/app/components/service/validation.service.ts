import { Injectable } from '@angular/core';

@Injectable({
  providedIn: 'root',
})
export class ValidationService {
  constructor() {}

  // Método para validar la longitud del nombre de la compañía
  validateCompanyNameLength(value: string, maxLength: number): boolean {
    // Verifica si el valor no es nulo y tiene una longitud válida
    return value !== null && value.length <= maxLength;
  }

  // Método para validar el número de teléfono
  validatePhoneNumber(phoneNumber: string): boolean {
    const pattern = /^(?=\(?\+?\d{1,3}\)?)(?=.{1,24}$)\(?\+?\d{1,3}\)?[\s-]?\d{1,24}$/;
    return pattern.test(phoneNumber);
  }
}