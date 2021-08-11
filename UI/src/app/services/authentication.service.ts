import { Injectable } from '@angular/core';
import { AuthenticationResponse } from '../models/user/user-authentication-response.model';
import { RegistrationResponse } from '../models/user/user-registration-response.model';
import { UserRegistration } from '../models/user/user-registration.model';
import { UserAuthentication } from '../models/user/user-authentication.model';

import { HttpClient } from '@angular/common/http';
import { JwtHelperService } from '@auth0/angular-jwt';
import { Subject } from 'rxjs';
import { environment } from 'src/environments/environment';
import { UserDto } from '../models/api/user-dto.model';

@Injectable({
  providedIn: 'root'
})
export class AuthenticationService {
  private _authChangeSub = new Subject<boolean>()
  public authChanged = this._authChangeSub.asObservable();
  
  constructor(private http: HttpClient, private jwtHelper: JwtHelperService) { 

  }

  public registerUser(body: UserRegistration){
    return this.http.post<RegistrationResponse>(`${environment.urlAddress}/user/registration`, body);
  }
  
  public loginUser(body: UserAuthentication){
    return this.http.post<AuthenticationResponse>(`${environment.urlAddress}/user/login`, body);
  }

  public getUser(){
    return this.http.get<UserDto>(`${environment.urlAddress}/user`);
  }
  
  public logout(){
    localStorage.removeItem("token");
    this.authStateChange(false);
  }

  public authStateChange(isAuthenticated: boolean){
    console.log("Authstate change.");
    this._authChangeSub.next(isAuthenticated);
  }

  public isUserAuthenticated(): boolean {
    const token = localStorage.getItem("token");
    
    return (token != null && !this.jwtHelper.isTokenExpired(token));
  }

  public isUserTutor(): boolean {
    const token = localStorage.getItem("token");
    if (token) {
      const role = this.jwtHelper.decodeToken(token)['http://schemas.microsoft.com/ws/2008/06/identity/claims/role'];
      return role == 'Tutor';
    }
    return false;
  }

  public isUserAdministrator(): boolean {
    const token = localStorage.getItem("token");
    if (token) {
      const role = this.jwtHelper.decodeToken(token)['http://schemas.microsoft.com/ws/2008/06/identity/claims/role'];
      return role == 'Administrator';
    }
    return false;
  }
}
