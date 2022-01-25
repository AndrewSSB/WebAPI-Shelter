import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Token } from '@angular/compiler';
import { Injectable } from '@angular/core';
import { tap } from 'rxjs';
import { environment } from 'src/environments/environment';

@Injectable({
  providedIn: 'root'
})
export class AuthService {
  private baseUrl:string = environment.baseUrl;
  private privateHttpHeaders = {
    headers: new HttpHeaders({
      'content-type': 'application/json',
      Authorization: 'Bearer ' + localStorage.getItem("token"),
    }),
  };
  constructor(private http: HttpClient) { }

  login(data:any){
    return this.http.post(`${this.baseUrl}/api/Auth/Login`, data, this.privateHttpHeaders);
  }

  register(data:any){
    return this.http.post(`${this.baseUrl}/api/Auth/Login`, data, this.privateHttpHeaders);
  }

  refreshToken(obj){
    return this.http.post(`${this.baseUrl}/api/Auth/Refresh`, obj, this.privateHttpHeaders);
  }
}
