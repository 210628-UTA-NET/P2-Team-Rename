import { Component, OnInit } from '@angular/core';
import {FormControl, FormGroup,  Validators } from '@angular/forms';
import { ActivatedRoute, Router } from '@angular/router';
import { UserAuthentication } from 'src/app/models/user/user-authentication.model';
import { AuthenticationService } from 'src/app/services/authentication.service';

@Component({
  selector: 'auth-login-user',
  templateUrl: './login-user.component.html',
  styleUrls: ['./login-user.component.scss']
})
export class LoginUserComponent implements OnInit {
  public loginForm: FormGroup = new FormGroup({
    email: new FormControl('', [Validators.required, Validators.email]),
    password: new FormControl('', [Validators.required]),
  });
  public errorMessage: string = '';
  public showError: boolean = false;
  private _returnUrl: string;
  constructor(private _authService: AuthenticationService, private _router: Router, private _route: ActivatedRoute) { 
    this._returnUrl = this._route.snapshot.queryParams['returnUrl'] || '/';
  }

  ngOnInit(): void {
  }

  public loginUser = (loginFormValue: any) => {
    this.showError = false;
    const login = {... loginFormValue };
    const userForAuth: UserAuthentication = {
      email: login.email,
      password: login.password
    }
    this._authService.loginUser('user/login', userForAuth)
    .subscribe(res => {
       localStorage.setItem("token", res.token);
       this._router.navigate([this._returnUrl]);
    },
    (error) => {
      this.errorMessage = error;
      this.showError = true;
    })
  }
}
