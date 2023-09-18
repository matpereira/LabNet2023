import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { environment } from 'src/app/environments/environment';
import { ResponseDto } from '../core/models/responseDto';

@Injectable({
  providedIn: 'root'
})
export class CustomerServiceService {
  apiUrl: string = environment.apiLab;


  constructor(private http: HttpClient) { }

  getAllCustomers(): Observable<ResponseDto> {
    let url = `${this.apiUrl}/Customers/GetAllCustomers`;
    return this.http.get<ResponseDto>(url); 
 }

 deleteCustomer(id: string): Observable<ResponseDto> {
  const url = `${this.apiUrl}/Customers/DeleteCustomer?id=${id}`;
  return this.http.delete<ResponseDto>(url);
}

addCustomer(customerData: any): Observable<ResponseDto> {
  const url = `${this.apiUrl}/Customers/AddCustomer`;
  return this.http.post<ResponseDto>(url, customerData);
}

updateCustomer(customerId: string, customerData: any): Observable<ResponseDto> {
  const url = `${this.apiUrl}/Customers/UpdateCustomer?id=${customerId}`;
  return this.http.put<ResponseDto>(url, customerData);
}

}
