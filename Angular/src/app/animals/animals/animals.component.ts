import { Component, OnDestroy, OnInit } from '@angular/core';
import { AbstractControl, FormControl, FormGroup } from '@angular/forms';
import { MatDialog, MatDialogConfig } from '@angular/material/dialog';
import { ActivatedRoute, Router } from '@angular/router';
import { Subscription } from 'rxjs';
import { AnimalsService } from 'src/app/services/animals.service';
import { AddEditAnimalsComponent } from '../../shared/add-edit-animals/add-edit-animals.component';

@Component({
  selector: 'app-animals',
  templateUrl: './animals.component.html',
  styleUrls: ['./animals.component.scss']
})
export class AnimalsComponent implements OnInit, OnDestroy{

  public loginForm: FormGroup = new FormGroup({
    id: new FormControl(),
  });

  public subscription: Subscription;
  public animals = [];
  public variable:any;
  public displayedColumns = ['id', 'specie', 'greutate', 'inaltime', 'sex', 'varsta', 'dataInmatriculare', 'adoptantiId', 'delete' ,'edit'];
 
  
  //public displayedColumns = ['id', 'nume', 'email', 'telefon'];

  constructor(
    private router: Router,
    private animalService: AnimalsService,
    private route:ActivatedRoute,
    private dialog: MatDialog,
  ) { }

  // get id(): AbstractControl {
  //   return this.loginForm?.get('id') as AbstractControl;
  // }

  public test:boolean = true;
  public check:any;

  ngOnInit(): void {
    this.subscription = this.route.params.subscribe(params =>{
      this.variable = +params['id']
      if (this.variable){
        this.animalService.idAdapost = this.variable;
        this.getAnimale();
      }
    });

    this.check = localStorage.getItem('Role');

    if(this.check == 'Admin'){
      this.test = false;
    }else{
      this.test = true;
    }

  }
  
  public getAnimale(): void {
    //console.log(this.loginForm.value.id);
    this.animalService.getAnimals(this.variable).subscribe(
      (result) => {
        this.animals = result;
      },
      (error) => {
        console.error(error);
      }
    );
  }

  ngOnDestroy(): void {
    this.subscription.unsubscribe();
  }

  public openModal(animal?): void {
    const data = {
      animal,
    };
    
    const dialogConfig = new MatDialogConfig();
    dialogConfig.width = '550px';
    dialogConfig.height = '700px';
    dialogConfig.data = data;
    const dialogRef = this.dialog.open(AddEditAnimalsComponent, dialogConfig);
    dialogRef.afterClosed().subscribe((result) => {
      if (result){
        this.animals = result;
      }
    });
  }

  public AddNewAnimal():void {
    this.openModal();
  }

  public updateAnimal(animal): void{
    this.openModal(animal);
  }

  public deleteAnimal(id:any): void{
    this.animalService.deleteAnimal(id).subscribe((result) =>
    {
      console.log("succces");
    }),
    (error) =>{
      console.error(error);
    };
  }
  
  public LogOut(){
    localStorage.clear();
    // localStorage.setItem('Role', 'Anonim');
    // localStorage.setItem('token', "");
    this.router.navigate(['login']);
  }

}
