import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { UserContactResponse } from '../models/user/user-contacts-response.model';
import { environment } from 'src/environments/environment';
import { UserDto } from '../models/api/user-dto.model';
import { AuthenticationService } from './authentication.service';

@Injectable({
  providedIn: 'root'
})
export class ContactService {
  public contacts: UserDto[] = [];

  constructor(private http: HttpClient, authService: AuthenticationService) { 
    if (authService.isUserAuthenticated()) {
      this.getUserContacts();
    }
  }

  public getUserContacts() {
    this.http.get<UserContactResponse>(`${environment.urlAddress}/user/contacts`).subscribe(res => {
      this.contacts = res.results;
    });
  }
}
