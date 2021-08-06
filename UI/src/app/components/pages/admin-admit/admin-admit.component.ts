import { HttpClient } from '@angular/common/http';
import { Component, OnInit } from '@angular/core';
import { EnvironmentUrlService } from 'src/app/services/environment-url.service';
import { JwtHelperService } from '@auth0/angular-jwt';

@Component({
  selector: 'app-admin-admit',
  templateUrl: './admin-admit.component.html',
  styleUrls: ['./admin-admit.component.scss']
})
export class AdminAdmitComponent implements OnInit {

  //list: ;//List of imported applications
  //selectedApplication?: ;//Variable for displaying application details
  
  constructor(private _http: HttpClient, private _envUrl: EnvironmentUrlService, private _jwtHelper: JwtHelperService) 
  { 

  }

  ngOnInit(): void 
  {
  }

  //onSelect(*: *) {
  //  this.selectedApplication = *;
  //}

}
