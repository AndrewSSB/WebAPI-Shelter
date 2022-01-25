import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { Adapost } from '../Interfaces/adapost';

@Injectable({
  providedIn: 'root'
})
export class AdapostService {

  public baseUrl = 'https://localhost:44390';

  private privateHttpHeaders = {
    headers: new HttpHeaders({
      'content-type': 'application/json',
      Authorization: 'Bearer ' + localStorage.getItem("token"),
    }),
  };

  constructor(
    public http: HttpClient,
  ) { }

  public getAdaposts(): Observable<Adapost[]> {
    return this.http.get<Adapost[]>(`${this.baseUrl}/api/Adapost/GetAdaposts`, this.privateHttpHeaders);
  }

  public deleteAdapost(id): Observable<any> {
    console.log(this.privateHttpHeaders.headers);
    return this.http.delete(`${this.baseUrl}/api/Adapost/DeleteAdapost?id=${id}`, this.privateHttpHeaders);
    //return this.http.get<any>(${this.url}/endpoint?param=${value})
  }

  public addAdapost(adapost) :Observable<any> {
    return this.http.post(`${this.baseUrl}/api/Adapost/AddAdapost`, adapost, this.privateHttpHeaders);
  }

  public updateAdapost(adapost : Adapost): Observable<Adapost[]> {
    return this.http.put<Adapost[]>(`${this.baseUrl}/api/Adapost/UpdateAdapost`, adapost, this.privateHttpHeaders);
  }
}
