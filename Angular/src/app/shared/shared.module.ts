import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { AddEditAdapostComponent } from './add-edit-adapost/add-edit-adapost.component';
import { MaterialModule } from '../material/material.module';
import { ReactiveFormsModule } from '@angular/forms';
import { HoverBtnDirective } from 'src/app/hover-btn.directive';
import { AddEditAnimalsComponent } from './add-edit-animals/add-edit-animals.component';



@NgModule({
  declarations: [
    AddEditAdapostComponent,
    HoverBtnDirective,
    AddEditAnimalsComponent
  ],
  imports: [
    CommonModule,
    MaterialModule,
    ReactiveFormsModule,
  ],
  entryComponents: [
    AddEditAdapostComponent
  ],
  exports: [
    HoverBtnDirective
  ]
})
export class SharedModule { }
