import { Injectable } from '@angular/core';
import { RegistrationResponse } from '../models/user/user-registration-response.model';
import { UserRegistration } from '../models/user/user-registration.model';
import { HttpClient } from '@angular/common/http';

@Injectable({
  providedIn: 'root'
})
export class AuthenticationService {

  constructor() { }
}
