import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormGroup } from '@angular/forms';

@Component({
  selector: 'app-login',
  templateUrl: './login.component.html',
  styleUrls: ['./login.component.scss']
})
export class LoginComponent implements OnInit {
  //display: string = "login";
  radioGroupForm: FormGroup;

  constructor(private formBuilder: FormBuilder) { 
    this.radioGroupForm = this.formBuilder.group({
      'display': "register"
    });
  }

  ngOnInit(): void {
  }

}
