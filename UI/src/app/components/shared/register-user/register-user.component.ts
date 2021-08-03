import { Component, OnInit } from '@angular/core';
import { AuthenticationService } from 'src/app/services/authentication.service';
import { FormControl, FormGroup, Validators } from '@angular/forms';
import { UserRegistration } from 'src/app/models/user/user-registration.model';

@Component({
  selector: 'app-register-user',
  templateUrl: './register-user.component.html',
  styleUrls: ['./register-user.component.scss']
})
export class RegisterUserComponent implements OnInit {
  public registerForm: FormGroup;

  constructor(private _authService: AuthenticationService) { 
    this.registerForm = new FormGroup({
      firstName: new FormControl(''),
      lastName: new FormControl(''),
      email: new FormControl('', [Validators.required, Validators.email]),
      password: new FormControl('', [Validators.required]),
      confirm: new FormControl('')
    });
  }

  ngOnInit(): void {}

  public validateControl = (controlName: string) => {
    return this.registerForm.controls[controlName].invalid && this.registerForm.controls[controlName].touched
  }
  public hasError = (controlName: string, errorName: string) => {
    return this.registerForm.controls[controlName].hasError(errorName)
  }
  public registerUser = (registerForm: FormGroup) => {
    const user: UserRegistration = {
      firstName: registerForm.get('firstName')!.value,
      lastName: registerForm.get('lastName')!.value,
      email: registerForm.get('email')!.value,
      password: registerForm.get('password')!.value,
      confirmPassword: registerForm.get('confirm')!.value,
    };
    this._authService.registerUser("/user/registration", user)
    .subscribe(_ => {
      console.log("Successful registration");
    },
    error => {
      console.log(error.error.errors);
    })
  }
}
