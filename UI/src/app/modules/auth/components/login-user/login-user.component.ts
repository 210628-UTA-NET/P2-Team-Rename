import { Component, OnInit, ViewChild } from '@angular/core';
import {FormControl, FormGroup,  Validators } from '@angular/forms';
import { ActivatedRoute, Router } from '@angular/router';
import { NgbAlert } from '@ng-bootstrap/ng-bootstrap';
import { UserAuthentication } from 'src/app/models/user/user-authentication.model';
import { AuthenticationService } from 'src/app/services/authentication.service';
import {debounceTime} from 'rxjs/operators';
import { Subject } from 'rxjs';

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

  private _error = new Subject<string>();

  @ViewChild('errorAlert', {static: false}) errorAlert: NgbAlert;

  constructor(private _authService: AuthenticationService, private router: Router, private route: ActivatedRoute) { 
    this.returnUrl = this.route.snapshot.queryParams['returnUrl'] || '/';
  }

  ngOnInit(): void {
    this._error.subscribe(message => this.errorMessage = message);
    this._error.pipe(debounceTime(5000)).subscribe(() => {
      if (this.errorAlert) {
        this.errorAlert.close();
      }
    });
  }

  public setErrorMessage(error: string) {
    this._error.next(error);
  }

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
       this._authService.changeAuthState(res.success);
       this._authService.refreshUser(res.user);
       this.router.navigate([this.returnUrl]);
    },
    (error) => {
      console.log(error);
      this.setErrorMessage(error);
    })
  }
}
