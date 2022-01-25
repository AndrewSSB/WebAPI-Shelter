import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs/internal/Observable';

@Injectable({
  providedIn: 'root'
})
export class AnimalsService {
  
  private privateHttpHeaders = {
    headers: new HttpHeaders({
      'content-type': 'application/json',
      Authorization: 'Bearer ' + localStorage.getItem("token"),
    }),
  };

  public baseUrl = 'https://localhost:44390';
  
  constructor(
    public http: HttpClient,
  ) { }

  public idAdapost;

  public getAnimals(id): Observable<any> {
    return this.http.get(`${this.baseUrl}/api/Animal/GetAnimalsById?id=${id}`, this.privateHttpHeaders);
    //return this.http.get<any>(${this.url}/endpoint?param=${value})
  }

  public addAnimal(animal) :Observable<any> {
    return this.http.post(`${this.baseUrl}/api/Animal/AddAnimal`, animal, this.privateHttpHeaders);
  }

  public editAnimal(animal): Observable<any>{
    return this.http.put(`${this.baseUrl}/api/Animal/UpdateAnimal`, animal, this.privateHttpHeaders);
  }

  public deleteAnimal(id): Observable<any>{
    return this.http.delete(`${this.baseUrl}/api/Animal/DeleteAnimal?id=${id}`, this.privateHttpHeaders);
  }
}
