import { Component, OnInit, ViewChild } from '@angular/core';
import { AuthenticationService } from 'src/app/services/authentication.service';
import { AbstractControl, FormControl, FormGroup, ValidatorFn, Validators } from '@angular/forms';
import { UserRegistration } from 'src/app/models/user/user-registration.model';
import { ActivatedRoute, Router } from '@angular/router';
import { Subject } from 'rxjs';
import { NgbAlert } from '@ng-bootstrap/ng-bootstrap';
import { debounceTime } from 'rxjs/operators';

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
    password: new FormControl('', [
      Validators.required,
      Validators.pattern('(?=.*[a-z])(?=.*[A-Z])(?=.*[0-9])(?=.*[$@$!%*?&])[A-Za-z\d$@$!%*?&].{8,}')
    ]),
    confirm: new FormControl('', [
      Validators.required,
      Validators.pattern('(?=.*[a-z])(?=.*[A-Z])(?=.*[0-9])(?=.*[$@$!%*?&])[A-Za-z\d$@$!%*?&].{8,}')
    ])
  }, {
    validators: [passwordMatch('password', 'confirm')]
  });

  returnUrl: string;
  private _error = new Subject<string>();
  public errorMessage: string = '';

  @ViewChild('errorAlert', {static: false}) errorAlert: NgbAlert;

  constructor(private authService: AuthenticationService, private router: Router) {
    this.returnUrl = '/';
  }

  ngOnInit(): void { 
    this._error.subscribe(message => this.errorMessage = message);
    this._error.pipe(debounceTime(5000)).subscribe(() => {
      if (this.errorAlert) {
        this.errorAlert.close();
      }
    });
  }

  public validateControl = (controlName: string) => {
    return this.registerForm.controls[controlName].invalid && this.registerForm.controls[controlName].touched
  }
  public hasError = (controlName: string, errorName: string) => {
    return this.registerForm.controls[controlName].hasError(errorName)
  }

  public setErrorMessage(error: string) {
    this._error.next(error);
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
    this.authService.registerUser(user)
      .subscribe(res => {
        localStorage.setItem("token", res.token);
        this.authService.changeAuthState(res.success);
        this.authService.refreshUser(res.user);
        this.router.navigate([this.returnUrl]);
      }, error => {
        this.setErrorMessage(error);
      })
  }
}
