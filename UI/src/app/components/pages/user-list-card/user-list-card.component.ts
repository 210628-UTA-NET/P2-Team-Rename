import { UserlistService } from 'src/app/services/userlist.service';
import { HttpClient } from '@angular/common/http';
import { Component, OnInit } from '@angular/core';
import { EnvironmentUrlService } from 'src/app/services/environment-url.service';
import { JwtHelperService } from '@auth0/angular-jwt';
import { UserDto } from 'src/app/models/api/user-dto.model';
import { TopicDto } from 'src/app/models/api/topic-dto.model';
import { LocationDto } from 'src/app/models/api/location-dto.model';
import { environment } from 'src/environments/environment';
import { Observable } from 'rxjs';
//import { getMaxListeners } from 'process';

@Component({
  selector: 'app-user-list-card',
  templateUrl: './user-list-card.component.html',
  styleUrls: ['./user-list-card.component.scss']
})
export class UserListCardComponent implements OnInit {
  [x: string]: any;

  list: UserDto[];//List of Users
  importlist: UserDto[];
  selectedUser?: any;//Variable for displaying user details
  toggled: boolean = false;

  constructor(private _http: HttpClient, private _userlist: UserlistService)
  {
      this.list = [{

        id: '5',
        firstName: 'Andy',
        lastName: 'Smith',
        email: 'andy@gmail.com',
        userName: 'andylearn',
        topics: [{topicName: 'Science'}],
        location: {
          longitude: 12,
          latitude: 43
        }

      }];
      this.getAllUsers();

  }

  ngOnInit(): void
  {
    //this._http.get<UserDto>
  }

  onSelect(person: any) {
    if(this.selectedUser == person)
    {
      console.log(person.id + " details closed");
      this.selectedUser = undefined;
    } else {
      console.log(person.id + " details opened");
      this.selectedUser = person;
    }
  }

  toRemove(person: UserDto)
  {
    console.log(person.id + " removed");
  }

  getAllUsers()
  {
    this._userlist.getAllUsers().subscribe(
      res => {
        this.importlist = res.results;
      }
    );
  }

}
