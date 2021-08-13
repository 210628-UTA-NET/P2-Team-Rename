import { TutorApplicationDto } from './../../../models/api/application-dto.model';
import { AdmitserviceService } from './../../../services/admitservice.service';
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

  list: TutorApplicationDto[];//List of imported applications
  selectedApplication?: TutorApplicationDto;//Variable for displaying application details
  toggled: boolean = false;

  constructor(private _http: HttpClient, private _admitlist: AdmitserviceService)
  {
      this.getAllApplications();
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
      this.selectedApplication?.topics.forEach(function (value)
      {
        console.log(value);
      });
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

  getAllApplications()
  {
    this._admitlist.getAllApplications().subscribe(
      res => {
        this.list = res.results;
      }
    );
  }

}
