import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';

import { AdapostRoutingModule } from './adapost-routing.module';
import { AdapostComponent } from './adapost/adapost.component';
import { MaterialModule } from '../material/material.module';
import { ChildComponent } from './child/child.component';


@NgModule({
  declarations: [
    AdapostComponent,
    ChildComponent
  ],
  imports: [
    CommonModule,
    AdapostRoutingModule,
    MaterialModule
  ]
})
export class AdapostModule { }
