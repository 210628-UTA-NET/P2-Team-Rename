import { JwtHelperService } from '@auth0/angular-jwt';
import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { UserDto } from '../models/api/user-dto.model';
import { EnvironmentUrlService } from './environment-url.service';
import { environment } from 'src/environments/environment';
import { UserSearchResponse } from '../models/user/user-search-response.model';
import { textChangeRangeIsUnchanged } from 'typescript';

@Injectable({
  providedIn: 'root'
})
export class UserlistService {

  constructor(private _http: HttpClient) { }

  getAllUsers()
  {
    return this._http.get<UserSearchResponse>(`${environment.urlAddress}/user/search`);
  }

  deleteUser(user: string)
  {
    this._http.delete(`${environment.urlAddress}/user/`+ user);
  }
}
