import { TutorApplicationDto } from './../../../models/api/application-dto.model';
import { degreeOrCert } from './../../../models/tutor/degreeOrCert';
import { HttpClient } from '@angular/common/http';
import { Component, OnInit } from '@angular/core';
import { EnvironmentUrlService } from 'src/app/services/environment-url.service';
import { JwtHelperService } from '@auth0/angular-jwt';
import { FormBuilder, FormControl, FormGroup } from '@angular/forms';
import { DegreeOrCertDto } from 'src/app/models/api/degreeOrCert-dto.model';
import { AdmitserviceService } from 'src/app/services/admitservice.service';
import { UserDto } from 'src/app/models/api/user-dto.model';
import { AuthenticationService } from 'src/app/services/authentication.service';

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
    degree: DegreeOrCertDto[] = [];
    topics: string[] = [];
    index: number = this.topics.length;
    public user: UserDto = {
      id: '',
      firstName: '',
      lastName: '',
      email: '',
      userName: '',
      topics:  [''],
      location: null,
    };

  constructor(private formBuilder: FormBuilder, private _admitlist: AdmitserviceService, public authService: AuthenticationService)
  {
    this.appForm = this.formBuilder.group({
      about: new FormControl(''),
      degreeTitle: new FormControl(''),
      degreeDetails: new FormControl(''),
      topics: new FormControl('')
    });
    this.authService.userInfo.subscribe(res => {
      this.user = res;
    });
  }

  ngOnInit(): void
  {

  }

  toSubmit()
  {
    this.about = this.appForm.get('about')?.value;
    console.log("Form Submitted " + this.user.firstName + this.about + " " + this.degree + " " + this.topics);
    var application: TutorApplicationDto =
    {
      user: this.user,
      about: this.about,
      degreesOrCerts: this.degree,
      topics: this.topics,
      id: '',
      timestamp: new Date

    };
    this._admitlist.postApplication(application);
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
    var degree: DegreeOrCertDto = {
      title: this.appForm.get('degreeTitle')?.value,
      details: this.appForm.get('degreeDetails')?.value
    };
    this.degree.push(degree);
    console.log(this.appForm.get('degreeTitle')?.value + "sumbitted");
    console.log(this.degree);
    this.appForm.get('degreeTitle')?.reset();
    this.appForm.get('degreeDetails')?.reset();
    this.degreetoggled = false;
  }



}
