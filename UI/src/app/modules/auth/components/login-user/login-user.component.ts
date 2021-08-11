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
  private returnUrl: string;

  constructor(private _authService: AuthenticationService, private router: Router, private route: ActivatedRoute) { 
    this.returnUrl = this.route.snapshot.queryParams['returnUrl'] || '/';
  }

  ngOnInit(): void {}

  public loginUser = (loginFormValue: any) => {
    this.showError = false;
    const login = {... loginFormValue };
    const userForAuth: UserAuthentication = {
      email: login.email,
      password: login.password
    }
    this._authService.loginUser(userForAuth)
    .subscribe(res => {
       localStorage.setItem("token", res.token);
       console.log("Login successful");
       this._authService.authStateChange(res.success);
       this.router.navigate([this.returnUrl]);
    },
    (error) => {
      this.errorMessage = error;
      this.showError = true;
    })
  }
}
