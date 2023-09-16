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
    
    // Verifica si la URL comienza con "http://" y reemplázala por "https://"
    if (url.startsWith("http://")) {
        url = url.replace("http://", "https://");
    }
    return this.http.get<ResponseDto>(url); 
 }
}
