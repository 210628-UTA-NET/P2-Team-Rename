import { environment } from 'src/environments/environment';
import { Observable } from 'rxjs';
import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Location } from '../models/tutor/location';
import { locationResponse } from '../models/user/locationResponse';

@Injectable({
  providedIn: 'root'
})
export class LocationService {

  constructor(private http: HttpClient) { }
  GetCityState(location: Location): Observable<locationResponse> {
    return this.http.get<locationResponse>(`${environment.POSI_STACK_URL}?access_key=${environment.POSI_STACK_KEY}&query=${location.Latitude},${location.Longitude}`)
  }
}
