import { HttpClient } from '@angular/common/http';
import { Component, OnInit } from '@angular/core';
import { EnvironmentUrlService } from 'src/app/services/environment-url.service';
import { JwtHelperService } from '@auth0/angular-jwt';

@Component({
  selector: 'app-tutor-apply',
  templateUrl: './tutor-apply.component.html',
  styleUrls: ['./tutor-apply.component.scss']
})
export class TutorApplyComponent implements OnInit {

    toggled: boolean = false;

    about: string = " ";
    degreeTitle: string = " ";
    degreeDetails: string = " ";
    topics: string[] | undefined;

  constructor(private _http: HttpClient, private _envUrl: EnvironmentUrlService, private _jwtHelper: JwtHelperService)
  {

  }

  ngOnInit(): void
  {

  }

  toSubmit()
  {
    console.log("Form Submitted");
  }



}
