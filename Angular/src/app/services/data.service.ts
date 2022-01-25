import { Injectable } from '@angular/core';
import { BehaviorSubject } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class DataService {

  private userSource = new BehaviorSubject({
    email: '',
    password: '',
  });

  public currentUser = this.userSource.asObservable();
  public Role:any = localStorage.getItem('Role');

  constructor() { }

  public changeUserData(user:any): void {
    this.userSource.next(user);
  }
}
