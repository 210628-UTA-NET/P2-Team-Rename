import { Injectable } from '@angular/core';
import { AuthenticationResponse } from '../models/user/user-authentication-response.model';
import { RegistrationResponse } from '../models/user/user-registration-response.model';
import { UserRegistration } from '../models/user/user-registration.model';
import { UserAuthentication } from '../models/user/user-authentication.model';

import { EnvironmentUrlService } from './environment-url.service';
import { HttpClient } from '@angular/common/http';
import { JwtHelperService } from '@auth0/angular-jwt';
import { Subject } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class AuthenticationService {
  private _authChangeSub = new Subject<boolean>()
  public authChanged = this._authChangeSub.asObservable();
  
  constructor(private _http: HttpClient, private _envUrl: EnvironmentUrlService, private _jwtHelper: JwtHelperService) { }

  public registerUser = (route: string, body: UserRegistration) => {
    return this._http.post<RegistrationResponse>(`${this._envUrl.urlAddress}/${route}`, body);
  }
  
  public loginUser = (route: string, body: UserAuthentication) => {
    return this._http.post<AuthenticationResponse>(`${this._envUrl.urlAddress}/${route}`, body);
  }
  
  public logout = () => {
    localStorage.removeItem("token");
    this.authStateChange(false);
  }

  public authStateChange = (isAuthenticated: boolean) => {
    this._authChangeSub.next(isAuthenticated);
  }

  public isUserAuthenticated = (): boolean => {
    const token = localStorage.getItem("token");
    return (token != null && !this._jwtHelper.isTokenExpired(token));
  }
}
