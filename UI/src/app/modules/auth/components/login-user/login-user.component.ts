import { Component, OnInit } from '@angular/core';
import {FormControl, FormGroup,  Validators } from '@angular/forms';

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
  constructor() { }

  ngOnInit(): void {
  }

  public loginUser = (registerForm: any) => {

  }

}
