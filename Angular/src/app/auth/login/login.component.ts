import { Component, OnInit } from '@angular/core';
import { AbstractControl, FormControl, FormGroup } from '@angular/forms';
import { Router } from '@angular/router';
import { AuthService } from 'src/app/services/auth.service';
import { DataService } from 'src/app/services/data.service';

@Component({
  selector: 'app-login',
  templateUrl: './login.component.html',
  styleUrls: ['./login.component.scss']
})
export class LoginComponent implements OnInit {

  public loginForm: FormGroup = new FormGroup({
    email: new FormControl(''),
    password: new FormControl(''),
  });

  constructor(
    private router:Router,
    private dataService: DataService,
    private authService: AuthService
  ) { }

  // getters
  get email(): AbstractControl {
    return this.loginForm?.get('email') as AbstractControl;
  }
  get password(): AbstractControl {
    return this.loginForm?.get('password') as AbstractControl;
  }

  ngOnInit(): void {
  }

  public error: string | boolean;

  public login(): void {
    this.error = false;

    if(this.validateEmail(this.loginForm.value['email'])){
      this.authService.login(this.loginForm.value).subscribe((response:any) => {
        if(response.success){
          localStorage.setItem('token', response.accesToken);
          localStorage.setItem('Role', response.role);
          localStorage.setItem('refreshToken', response.refreshToken);
          this.router.navigate(['/adapost']);
        }else{
          this.error = "Email or password is incorect";
        }
      }); //subscribe pt a avea rasp de la sv
    }else{
      this.error = "Email is not valid";
    }
  }

  validateEmail(email: string) {
    const re = /^(([^<>()[\]\\.,;:\s@"]+(\.[^<>()[\]\\.,;:\s@"]+)*)|(".+"))@((\[[0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}\])|(([a-zA-Z\-0-9]+\.)+[a-zA-Z]{2,}))$/;
    return re.test(String(email).toLowerCase());
  }

  public moveToSignIn(){
    this.router.navigate(['register']);
  }
}
