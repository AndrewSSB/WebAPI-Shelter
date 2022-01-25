import { AfterContentInit, AfterViewInit, Component, ElementRef, Inject, OnInit, ViewEncapsulation } from '@angular/core';
import { AbstractControl, FormControl, FormGroup } from '@angular/forms';
import { MatDialogRef, MAT_DIALOG_DATA } from '@angular/material/dialog';
import { AdapostService } from 'src/app/services/adapost.service';

@Component({
  selector: 'app-add-edit-adapost',
  templateUrl: './add-edit-adapost.component.html',
  styleUrls: ['./add-edit-adapost.component.scss'],
  encapsulation: ViewEncapsulation.None
})
export class AddEditAdapostComponent implements OnInit, AfterViewInit {

  public adapostForm: FormGroup = new FormGroup({
    id: new FormControl(''),
    nume: new FormControl(''),
    email: new FormControl(''),
    telefon: new FormControl(''),
    locationId: new FormControl(''),
  });

  public title;
  public check: boolean;

  constructor(
    @Inject(MAT_DIALOG_DATA) public data,
    private adapostService: AdapostService,
    public dialogRef: MatDialogRef<AddEditAdapostComponent>,
    private elementRef: ElementRef,
  ) { 
    if (data.adapost){
      this.title = 'Edit Adapost';
      this.check = false;
      this.adapostForm.patchValue(this.data.adapost);
    }else {
      this.title = 'Add Adapost'
      this.check = true;
    }
  }

  //getter

  // get id(): AbstractControl {
  //   return this.adapostForm.get('id');
  // }

  get nume(): AbstractControl {
    return this.adapostForm?.get('nume');
  }

  get email(): AbstractControl {
    return this.adapostForm.get('email');
  }

  get telefon(): AbstractControl {
    return this.adapostForm.get('telefon');
  }

  get locationId(): AbstractControl {
    return this.adapostForm.get('locationId');
  }

  ngOnInit(): void {
  }

  public addAdapost(): void {
    const obj = {
      nume: this.adapostForm.value['nume'],
      email: this.adapostForm.value['email'],
      telefon: this.adapostForm.value['telefon'],
      locationId: this.adapostForm.value['locationId']
    }
    this.adapostService.addAdapost(obj).subscribe(
      (result) => {
        //setTimeout(window.location.reload, 1000);
        console.log("Succes");
        this.dialogRef.close(result);
      },
      (error) => {
        console.error(error);
      }
    );
    // console.log(this.adapostForm.value);
  }

  public editAdapost() : void {
    this.adapostService.updateAdapost(this.adapostForm.value).subscribe(
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

  ngAfterViewInit() {
    this.elementRef.nativeElement.ownerDocument
        .body.style.backgroundColor = '#345B63';
}

}
