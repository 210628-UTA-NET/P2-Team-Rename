import { HttpClient } from '@angular/common/http';
import { Component, OnInit } from '@angular/core';
import { EnvironmentUrlService } from 'src/app/services/environment-url.service';
import { JwtHelperService } from '@auth0/angular-jwt';

@Component({
  selector: 'app-admin-admit-card',
  templateUrl: './admin-admit-card.component.html',
  styleUrls: ['./admin-admit-card.component.scss']
})
export class AdminAdmitCardComponent implements OnInit {

  list: any;//List of imported applications
  selectedApplication?: any;//Variable for displaying application details
  toggled: boolean = false;

  constructor(private _http: HttpClient, private _envUrl: EnvironmentUrlService, private _jwtHelper: JwtHelperService)
  {

  }

  ngOnInit(): void
  {
    //this.list = this._jwtHelper.GetApplications();
  }

  onSelect(selected: any) {
    if(this.selectedApplication == selected)
    {
      console.log(selected.id + " details closed");
      this.selectedApplication = undefined;
    } else {
      console.log(selected.id + " details opened");
      this.selectedApplication = selected;
    }
  }

  toAccept(selected: any)
  {
    console.log(selected.id + " Accepted");
  }

  toRemove(selected: any)
  {
    console.log(selected.id + " Rejected");
  }

}
