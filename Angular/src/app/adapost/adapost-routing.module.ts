import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { AdapostComponent } from './adapost/adapost.component';


const routes: Routes = [
  {
    path: '',
    component: AdapostComponent,
  }
];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule]
})
export class AdapostRoutingModule { }
