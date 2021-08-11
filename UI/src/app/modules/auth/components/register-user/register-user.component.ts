import { Component, OnInit } from '@angular/core';
import { AuthenticationService } from 'src/app/services/authentication.service';
import { AbstractControl, FormControl, FormGroup, ValidatorFn, Validators } from '@angular/forms';
import { UserRegistration } from 'src/app/models/user/user-registration.model';
import { ActivatedRoute, Router } from '@angular/router';

export function passwordMatch(controlName: string, checkControlName: string): ValidatorFn {
  return (controls: AbstractControl) => {
    const control = controls.get(controlName);
    const checkControl = controls.get(checkControlName);

    if (checkControl?.errors && !checkControl.errors.matching) {
      return null;
    }

    if (control?.value !== checkControl?.value) {
      controls.get(checkControlName)?.setErrors({ matching: true });
      return { matching: true };
    } else {
      return null;
    }
  };
}

@Component({
  selector: 'auth-register-user',
  templateUrl: './register-user.component.html',
  styleUrls: ['./register-user.component.scss']
})

export class RegisterUserComponent implements OnInit {
  public registerForm: FormGroup = new FormGroup({
    firstName: new FormControl(''),
    lastName: new FormControl(''),
    email: new FormControl('', [Validators.required, Validators.email]),
    password: new FormControl('', [Validators.required]),
    confirm: new FormControl('', [Validators.required])
  }, {
    validators: [passwordMatch('password', 'confirm')]
  });

  returnUrl: string;
  

  constructor(private authService: AuthenticationService, private router: Router, private route: ActivatedRoute) {
    this.returnUrl = this.route.snapshot.queryParams['returnUrl'] || '/';
  }

  ngOnInit(): void { }

  public validateControl = (controlName: string) => {
    return this.registerForm.controls[controlName].invalid && this.registerForm.controls[controlName].touched
  }
  public hasError = (controlName: string, errorName: string) => {
    return this.registerForm.controls[controlName].hasError(errorName)
  }
  public registerUser = (registerForm: any) => {
    const formValues = { ...registerForm };
    const user: UserRegistration = {
      firstName: formValues.firstName,
      lastName: formValues.lastName,
      email: formValues.email,
      password: formValues.password,
      confirmPassword: formValues.confirm
    };
    this.authService.registerUser("user/registration", user)
      .subscribe(response => {
        localStorage.setItem("token", response.token);
        this.authService.authStateChange(response.isSuccessfulRegistration);
        this.router.navigate([this.returnUrl]);
        console.log("Successful registration");
      }, error => {
          console.log(error.error.errors);
      })
  }
}
