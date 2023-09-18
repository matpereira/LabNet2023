import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { environment } from 'src/app/environments/environment';
import { ResponseDto } from '../core/models/responseDto';

@Injectable({
  providedIn: 'root'
})
export class ShipperServiceService {
  apiUrl: string = environment.apiLab;


  constructor(private http: HttpClient) { }

  getAllShippers(): Observable<ResponseDto> {
    let url = `${this.apiUrl}/Shippers/GetAllShippers`;
    return this.http.get<ResponseDto>(url); 
 }

 deleteShipper(id: number): Observable<ResponseDto> {
  const url = `${this.apiUrl}/Shippers/DeleteShipper?id=${id}`;
  return this.http.delete<ResponseDto>(url);
}

addShipper(shipperData: any): Observable<ResponseDto> {
  const url = `${this.apiUrl}/Shippers/AddShippers`;
  return this.http.post<ResponseDto>(url, shipperData);
}

editShipper(shipperId: number, shipperData: any): Observable<ResponseDto> {
  const url = `${this.apiUrl}/Shippers/UpdateShipper?id=${shipperId}`;
  return this.http.put<ResponseDto>(url, shipperData);
}

}
