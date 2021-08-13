import { ResponseTutor } from './../models/tutor/responseTutor';
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
  private bookingPath = `${this.appointmentsPath}/book`;

  constructor(private http: HttpClient) {}

  GetTutorAppointments(query: string): Observable<{results: Appointment[]}> {
    const re = /=|&/;
    let available: Appointment[] = [];
    let queryArr = query.split(re);
    let TutorId = queryArr[3];

    if (queryArr[1] === 'true')
    {
      available = appointments.filter(appt => (appt.userId === null && appt.tutorId === TutorId));
    }

    return of({results: available});
  }

  GetAPITutorAppointments(query: string): Observable<{results: Appointment[]}> {
    return this.http.get<{results: Appointment[]}>(`${environment.urlAddress}/${this.appointmentsPath}${query}`);
  }

  BookAppointment(appointmentId: string): Observable<{results: Appointment}> {
    let bookedAppointment = appointments.find(appointment => appointment.id === appointmentId);
    if (bookedAppointment && bookedAppointment.userId === null) {
        bookedAppointment.userId = '10';
        return of({results: bookedAppointment});
    }
    return of({results: {
      id: '',
      date: new Date(0, 0, 0, 0, 0),
      tutorId: '',
      userId: ''
    }});
  }

  BookAPIAppointment(appointmentID: string): Observable<{results: Appointment}> {
    return this.http.patch<{results: Appointment}>(`${this.bookingPath}/${appointmentID}`, {});
  }

  SearchTutors(queryString: string): Observable<{results: Tutor[]}> {
    let foundTutors = TUTORS.filter((tutor) =>
      tutor.topics.some(
        (topic) =>
          topic.toLowerCase().indexOf(queryString.split(/=|&|\?/)[2].trim().toLowerCase()) != -1
      )
    );



    let re = /=|&|\?/;
    let queryArr = queryString.split(re);
    if (queryArr.length > 3) {
      if (queryArr[4] === 'Price') {
        foundTutors = foundTutors.sort((tutor1, tutor2) => tutor1.hourlyRate - tutor2.hourlyRate);
      }
      if (queryArr[4] === 'Rating_desc') {
        foundTutors = foundTutors.sort((tutor1, tutor2) => tutor2.rating - tutor1.rating);
      }
    }
    return of({results: foundTutors});
  }

  SearchAPITutors(queryString: string): Observable<{results: Tutor[]}> {
    return this.http.get<{results: Tutor[]}>(`${environment.urlAddress}/${this.tutorsPath}${queryString}`);
  }
  GetTutor(tutorID: string): Observable<Tutor> {
    let defaultTutor: Tutor = {
      id: '',
        firstName: '',
        lastName: '',
        email: '',
        userName: '',
        topics: [],
        location: {
          longitude: 0,
          latitude: 0,
        },
      about: '',
      hourlyRate: 0,
      degreesOrCerts: [],
      rating: 0,
    };
    let foundTutor = TUTORS.find((tutor) => (tutor.id === tutorID));
    if (foundTutor === undefined) {
      return of(defaultTutor);
    }
    return of(foundTutor);
  }
}
