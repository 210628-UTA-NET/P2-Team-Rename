import { HttpClient } from '@angular/common/http';
import { Component, OnInit } from '@angular/core';
import { EnvironmentUrlService } from 'src/app/services/environment-url.service';
import { JwtHelperService } from '@auth0/angular-jwt';

@Component({
  selector: 'app-user-list-card',
  templateUrl: './user-list-card.component.html',
  styleUrls: ['./user-list-card.component.scss']
})
export class UserListCardComponent implements OnInit {

  list: any;//List of Users
  selectedUser?: any;//Variable for displaying user details
  toggled: boolean = false;

  constructor(private _http: HttpClient, private _envUrl: EnvironmentUrlService, private _jwtHelper: JwtHelperService)
  {

  }

  ngOnInit(): void
  {
    //this.list = this._jwtHelper.GetUsers();
  }

  //onSelect(person: any) {
  //  this.selectedUser = person;
  //}

}
