import { Component, OnDestroy, OnInit } from '@angular/core';
import { MatDialog, MatDialogConfig } from '@angular/material/dialog';
import { Router } from '@angular/router';
import { Subscription } from 'rxjs';
import { Adapost } from 'src/app/Interfaces/adapost';
import { User } from 'src/app/Interfaces/user';
import { AdapostService } from 'src/app/services/adapost.service';
import { AuthService } from 'src/app/services/auth.service';
import { DataService } from 'src/app/services/data.service';
import { AddEditAdapostComponent } from '../../shared/add-edit-adapost/add-edit-adapost.component';

@Component({
  selector: 'app-adapost',
  templateUrl: './adapost.component.html',
  styleUrls: ['./adapost.component.scss']
})
export class AdapostComponent implements OnInit, OnDestroy{

  public subscription: Subscription;
  public loggedUser:User;
  public parentMessage = 'message from parent';
  public adaposts: Adapost[] = [];
  public displayedColumns = ['id', 'nume', 'email', 'telefon', 'locationId','delete', 'edit'];

  public test:boolean = true;
  public check:any;


  public obj = {
    token: localStorage.getItem('token'),
    refreshToken: localStorage.getItem('refreshToken'),
  }

  constructor(
    private router: Router,
    private dataService: DataService,
    private adapostService: AdapostService,
    private dialog: MatDialog,
    private authService: AuthService,
  ) { }

  private tokenExpired(token: string) {
    const expiry = (JSON.parse(atob(token.split('.')[1]))).exp;
    return (Math.floor((new Date).getTime() / 1000)) >= expiry;
  }

  ngOnInit(): void {
    this.subscription = this.dataService.currentUser.subscribe((user:User) => this.loggedUser = user);
    
    this.check = localStorage.getItem('Role');

    if(this.check == 'Admin'){
      this.test = false;
    }else{
      this.test = true;
    }
    
    this.adapostService.getAdaposts().subscribe(
      (result:Adapost[]) => {
        this.adaposts = result;
      },
      (error) => {
        console.error(error);
      }
    );

    if (localStorage.getItem('token') && localStorage.getItem('refreshToken')) {
      if (this.tokenExpired(localStorage.getItem('token'))){
        //console.log("ESTI IN REFRESH");
        console.log(this.obj);
        this.authService.refreshToken(this.obj).subscribe(
          (result:any) => {
            localStorage.setItem('token', result.token);
            //localStorage.setItem('refreshToken', result.refreshToken);
          },
          (error) => {
            console.error(error);
          }
        );
      }
    } else {
        console.log("Not refresh");
    }
  }

  ngOnDestroy(): void {
    this.subscription.unsubscribe();
  }

  public logout(): void {
    //localStorage.setItem('Role', 'Anonim');
    localStorage.clear();
    this.router.navigate(['/login']);
  }

  public sender(id:any): void {
    this.router.navigate(['/animals', id]);
  }

  public receiveMessage(event): void {
    console.log(event)
  }

  public deleteAdapost(id:any): void{
    this.adapostService.deleteAdapost(id).subscribe((result) =>
    {
      console.log("succces");
    }),
    (error) =>{
      console.error(error);
    };
  }

  public openModal(adapost?): void {
    const data = {
      adapost
    };
    const dialogConfig = new MatDialogConfig();
    dialogConfig.width = '550px';
    dialogConfig.height = '700px';
    dialogConfig.data = data;
    const dialogRef = this.dialog.open(AddEditAdapostComponent, dialogConfig);
    dialogRef.afterClosed().subscribe((result) => {
      if (result){
        this.adaposts = result;
      }
    });
  }

  public addNewAdapost():void {
    this.openModal();
  }

  public updateAdapost(adapost): void {
    this.openModal(adapost);
  }

  public LogOut(){
    localStorage.setItem('Role', 'Anonim');
    localStorage.setItem('token', "");
    this.router.navigate(['login']);
  }
}
