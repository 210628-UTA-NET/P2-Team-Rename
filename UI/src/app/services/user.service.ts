import { environment } from 'src/environments/environment';
import { Appointment } from './../models/tutor/appointment';
import { TUTORS } from './mock-tutors';
import { Tutor } from './../models/tutor/tutor';
import { Injectable } from '@angular/core';
import { Observable, of } from 'rxjs';
import { appointments } from './mock-appointments';
import { HttpClient } from '@angular/common/http';

@Injectable({
  providedIn: 'root',
})
export class UserService {
  private tutorsPath = 'tutor';
  private appointmentsPath = 'appointment';

  constructor(private http: HttpClient) {}

  GetTutorAppointments(query: string): Observable<Appointment[]> {
    const re = /=|&/;
    let available: Appointment[] = [];
    let queryArr = query.split(re);
    let TutorId = queryArr[3];

    if (queryArr[1] === 'true')
    {
      available = appointments.filter(appt => (appt.UserId === null && appt.TutorId === TutorId));
    }

    return of(available);
  }

  GetAPITutorAppointments(query: string): Observable<{Results:Appointment[]}> {
    return this.http.get<{Results: Appointment[]}>(`${environment.urlAddress}/${this.appointmentsPath}${query}`);
  }

  BookAppointment(appointmentId: string): Observable<Appointment> {
    let bookedAppointment = appointments.find(appointment => appointment.Id === appointmentId);
    if (bookedAppointment && bookedAppointment.UserId === null) {
        bookedAppointment.UserId = '10';
        return of(bookedAppointment);
    }
    return of({
      Id: '',
      Date: new Date(0, 0, 0, 0, 0),
      TutorId: '',
      UserId: ''
    });
  }

  SearchTutors(queryString: string): Observable<Tutor[]> {
    let foundTutors = TUTORS.filter((tutor) =>
      tutor.Topics.some(
        (topic) =>
          topic.toLowerCase().indexOf(queryString.split(/=|&|\?/)[2].trim().toLowerCase()) != -1
      )
    );



    let re = /=|&|\?/;
    let queryArr = queryString.split(re);
    console.log('queryArr: ')
    console.log(queryArr);
    console.log(queryString);
    if (queryArr.length > 3) {
      if (queryArr[4] === 'Price') {
        console.log('Before Sorting');
        console.log(foundTutors);
        foundTutors = foundTutors.sort((tutor1, tutor2) => tutor1.HourlyRate - tutor2.HourlyRate);
        console.log('After Sorting');
        console.log(foundTutors)
      }
      if (queryArr[4] === 'Rating_desc') {
        console.log('Before Sorting');
        console.log(foundTutors);
        foundTutors = foundTutors.sort((tutor1, tutor2) => tutor2.Rating - tutor1.Rating);
        console.log('After Sorting');
        console.log(foundTutors)
      }
    }
    return of(foundTutors);
  }

  SearchAPITutors(queryString: string): Observable<{Results: Tutor[]}> {
    return this.http.get<{Results: Tutor[]}>(`${environment.urlAddress}/${this.tutorsPath}${queryString}`);
  }
  GetTutor(tutorID: string): Observable<Tutor> {
    let defaultTutor: Tutor = {
      Id: '',
        FirstName: '',
        LastName: '',
        Email: '',
        UserName: '',
        Topics: [],
        Location: {
          Longitude: 0,
          Latitude: 0,
        },
      About: '',
      HourlyRate: 0,
      DegreesOrCerts: [],
      Rating: 0,
    };
    let foundTutor = TUTORS.find((tutor) => (tutor.Id === tutorID));
    if (foundTutor === undefined) {
      return of(defaultTutor);
    }
    return of(foundTutor);
  }
}
