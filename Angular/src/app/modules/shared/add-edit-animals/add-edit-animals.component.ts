import { identifierName, ThisReceiver } from '@angular/compiler';
import { Component, ElementRef, Inject, Input, OnInit } from '@angular/core';
import { AbstractControl, FormControl, FormGroup } from '@angular/forms';
import { MatDialogRef, MAT_DIALOG_DATA } from '@angular/material/dialog';
import { ActivatedRoute } from '@angular/router';
import { Subscription } from 'rxjs';
import { AnimalsService } from 'src/app/services/animals.service';

@Component({
  selector: 'app-add-edit-animals',
  templateUrl: './add-edit-animals.component.html',
  styleUrls: ['./add-edit-animals.component.scss']
})
export class AddEditAnimalsComponent implements OnInit {

  @Input() item = '';

  public animalForm: FormGroup = new FormGroup({
    id: new FormControl(''),
    specie: new FormControl(''),
    greutate: new FormControl(''),
    inaltime: new FormControl(''),
    sex: new FormControl(''),
    varsta: new FormControl(''),
    adoptantiId: new FormControl(''),
    dataInmatriculare: new FormControl(''),
  });

  public title;

  constructor(
    @Inject(MAT_DIALOG_DATA) public data,
    private animalService: AnimalsService,
    public dialogRef: MatDialogRef<AddEditAnimalsComponent>,
  ) {
    if (data.animal){
      this.title = 'Edit Animal';
      this.animalForm.patchValue(this.data.animal);
    }else {
      this.title = 'Add Animal';
      console.log("Aiapasat")
    }
   }

  public variable:any;

  get nume(): AbstractControl {
    return this.animalForm.get('nume');
  }

  get specie(): AbstractControl {
    return this.animalForm.get('specie');
  }

  get greutate(): AbstractControl {
    return this.animalForm.get('greutate');
  }

  get sex(): AbstractControl {
    return this.animalForm.get('sex');
  }

  get inaltime(): AbstractControl {
    return this.animalForm.get('inaltime');
  }

  get varsta(): AbstractControl {
    return this.animalForm.get('varsta');
  }

  get dataInmatriculare(): AbstractControl {
    return this.animalForm.get('DataInmatriculare');
  }

  get adoptantiId(): AbstractControl {
    return this.animalForm.get('adoptantiId');
  }

  ngOnInit(): void {
  }

  public copy:any;

  public addAnimal(): void {

    if (!this.animalForm.value['idAdoptant']){
      this.animalForm.value['idAdoptant'] = null;
    }

    const obj = {
      dataInmatriculare: this.animalForm.value['dataInmatriculare'],
      specie: this.animalForm.value['specie'],
      greutate: this.animalForm.value['greutate'],
      inaltime: this.animalForm.value['inaltime'],
      varsta: this.animalForm.value['varsta'],
      sex: this.animalForm.value['sex'],
      AdapostId: this.animalService.idAdapost.toString(),
      AdoptantiId: this.animalForm.value['AdoptantiId'],
    }

    console.log(obj);

    this.animalService.addAnimal(obj).subscribe(
      (result) => {
        console.log("Succes");
        this.dialogRef.close(result);
      },
      (error) => {
        console.error(error);
      }
    );
  }

  public editAnimal() : void {

    const obj = {
      Id: this.animalForm.value['id'],
      dataInmatriculare: this.animalForm.value['dataInmatriculare'],
      specie: this.animalForm.value['specie'],
      greutate: this.animalForm.value['greutate'],
      inaltime: this.animalForm.value['inaltime'],
      varsta: this.animalForm.value['varsta'],
      sex: this.animalForm.value['sex'],
      AdapostId: this.animalService.idAdapost.toString(),
      adoptantiId: this.animalForm.value['adoptantiId'],
    }

    console.log(obj);

    this.animalService.editAnimal(obj).subscribe(
      (result) => {
        //setTimeout(window.location.reload, 1000);
        console.log("Succes");
        this.dialogRef.close(result);
      },
      (error) => {
        console.error(error);
      }
    );
  }
}
