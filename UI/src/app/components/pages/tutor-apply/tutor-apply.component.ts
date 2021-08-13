import { degreeOrCert } from './../../../models/tutor/degreeOrCert';
import { HttpClient } from '@angular/common/http';
import { Component, OnInit } from '@angular/core';
import { EnvironmentUrlService } from 'src/app/services/environment-url.service';
import { JwtHelperService } from '@auth0/angular-jwt';
import { FormBuilder, FormControl, FormGroup } from '@angular/forms';

@Component({
  selector: 'app-tutor-apply',
  templateUrl: './tutor-apply.component.html',
  styleUrls: ['./tutor-apply.component.scss']
})
export class TutorApplyComponent implements OnInit {

    toggled: boolean = false;
    degreetoggled: boolean = false;
    topictoggled: boolean = false;

    appForm: FormGroup;

    about: string = " ";
    degree: degreeOrCert[] = [];
    topics: string[] = [];
    index: number = this.topics.length;

  constructor(private formBuilder: FormBuilder)
  {
    this.appForm = this.formBuilder.group({
      about: new FormControl(''),
      degreeTitle: new FormControl(''),
      degreeDetails: new FormControl(''),
      topics: new FormControl('')
    });
  }

  ngOnInit(): void
  {

  }

  toSubmit()
  {
    this.about = this.appForm.get('about')?.value;
    console.log("Form Submitted " + this.about + " " + this.degree + " " + this.topics);
  }

  addTopic()
  {
    this.topictoggled = !this.topictoggled;
  }

  addDegree()
  {
    this.degreetoggled = !this.degreetoggled;
  }

  submitTopic()
  {
    this.topics.push(this.appForm.get('topics')?.value);
    console.log(this.appForm.get('topics')?.value + "sumbitted");
    console.log(this.topics);
    this.appForm.get('topics')?.reset();
    this.topictoggled = false;
  }

  submitDegree()
  {
    var degree: degreeOrCert = {
      Title: this.appForm.get('degreeTitle')?.value,
      Details: this.appForm.get('degreeDetails')?.value
    };
    this.degree.push(degree);
    console.log(this.appForm.get('degreeTitle')?.value + "sumbitted");
    console.log(this.degree);
    this.appForm.get('degreeTitle')?.reset();
    this.appForm.get('degreeDetails')?.reset();
    this.degreetoggled = false;
  }



}
