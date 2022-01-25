import { Component, OnInit } from '@angular/core';
import { AbstractControl, FormControl, FormGroup } from '@angular/forms';
import { Router } from '@angular/router';
import { AuthService } from 'src/app/services/auth.service';

@Component({
  selector: 'app-register',
  templateUrl: './register.component.html',
  styleUrls: ['./register.component.scss']
})
export class RegisterComponent implements OnInit {

  public registerForm: FormGroup = new FormGroup({
    email: new FormControl(''),
    password: new FormControl(''),
    role: new FormControl('')
  });

  constructor(
    private router: Router,
    private authService: AuthService
  ) { }

  get email(): AbstractControl {
    return this.registerForm?.get('email') as AbstractControl;
  }
  get password(): AbstractControl {
    return this.registerForm?.get('password') as AbstractControl;
  }

  ngOnInit(): void {
  }

  public error: string | boolean;

  public register(): void {
    this.error = false;
    console.log(this.registerForm.value);

    this.registerForm.value['role'] = "User";

    if(this.validateEmail(this.registerForm.value['email'])){
      this.authService.register(this.registerForm.value).subscribe((response:any) => {
        this.router.navigate(['login']);
        if(response){
          //localStorage.setItem('token', response.accesToken);
          //localStorage.setItem('Role', 'Admin');
          console.log("Succes");
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

  public moveToLogin(){
    this.router.navigate(['login']);
  }

}
