import { TutorApplicationDto } from './../models/api/application-dto.model';
import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';

import { environment } from 'src/environments/environment';
import { ApplicationGetResponse } from '../models/api/application-get-response.model';

@Injectable({
  providedIn: 'root'
})
export class AdmitserviceService {

  constructor(private _http: HttpClient) { }

  getAllApplications()
  {
    return this._http.get<ApplicationGetResponse>(`${environment.urlAddress}/application`);
  }

  postApplication(application: any)
  {
    this._http.post(`${environment.urlAddress}/application`, application);
  }

  deleteApplication(application: string)
  {
    this._http.delete(`${environment.urlAddress}/application/`+ application);
  }

  patchApplication(application: string)
  {
    this._http.patch(`${environment.urlAddress}/application/`, application);
  }
}
