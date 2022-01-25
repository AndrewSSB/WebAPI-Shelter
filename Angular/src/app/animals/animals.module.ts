import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';

import { AnimalsRoutingModule } from './animals-routing.module';
import { AnimalsComponent } from './animals/animals.component';
import { MaterialModule } from '../material/material.module';
import { ReactiveFormsModule } from '@angular/forms';
import { ChildComponent } from '../adapost/child/child.component';

@NgModule({
  declarations: [
    AnimalsComponent,
  ],
  imports: [
    CommonModule,
    AnimalsRoutingModule,
    MaterialModule,
    ReactiveFormsModule,
  ]
})
export class AnimalsModule { }
