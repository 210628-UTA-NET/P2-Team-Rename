import { Appointment } from './../models/tutor/appointment';
import { TUTORS } from './mock-tutors';
import { UserModule } from './../modules/user/user.module';
import { Tutor } from './../models/tutor/tutor';
import { Injectable } from '@angular/core';
import { Observable, of } from 'rxjs';
import { appointments } from './mock-appointments';

@Injectable({
  providedIn: 'root',
})
export class UserService {
  private tutorsUrl = 'api/tutors';

  constructor() {}

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
          topic.toLowerCase().indexOf(queryString.split('=')[1].trim().toLowerCase()) != -1
      )
    );
    return of(foundTutors);
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
