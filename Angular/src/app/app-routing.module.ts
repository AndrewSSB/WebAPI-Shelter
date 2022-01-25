import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { AuthGuard } from './auth.guard';

const routes: Routes = [
  {
    path: '',
    canActivate: [AuthGuard],
    children: [
      {
        path: '',
        redirectTo: 'adapost',
        pathMatch: 'full',
      },
      {      
        path: 'adapost',
        loadChildren: () => import('src/app/modules/adapost/adapost.module').then(m => m.AdapostModule),
      },   
      {
        path: 'animals/:id',
        loadChildren: () => import('src/app/modules/animals/animals.module').then(m => m.AnimalsModule),
      },
    ]
  },
  {
    path: '',
    loadChildren: () => import('src/app/modules/auth/auth.module').then(m => m.AuthModule),
  },
  {
    path: 'register',
    loadChildren: () => import('src/app/modules/register/register.module').then(m=>m.RegisterModule),
  }
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
