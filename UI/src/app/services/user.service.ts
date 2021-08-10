import { TUTORS } from './mock-tutors';
import { UserModule } from './../modules/user/user.module';
import { Tutor } from './../models/tutor/tutor';
import { Injectable } from '@angular/core';
import { Observable, of } from 'rxjs';

@Injectable({
  providedIn: 'root',
})
export class UserService {
  private tutorsUrl = 'api/tutors';

  constructor() {}

  SearchTutors(searchTopic: string): Observable<Tutor[]> {
    let foundTutors = TUTORS.filter((tutor) =>
      tutor.User.Topics.some(
        (topic) =>
          topic.toLowerCase().indexOf(searchTopic.trim().toLowerCase()) != -1
      )
    );
    return of(foundTutors);
  }
  GetTutor(tutorID: string): Observable<Tutor> {
    let defaultTutor: Tutor = {
      Id: '',
      User: {
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
      },
      About: '',
      HourlyRate: 0,
      DegreesOrCerts: [],
      Rating: 0,
    };
    let foundTutor = TUTORS.find((tutor) => (tutor.Id = tutorID));
    if (foundTutor === undefined) {
      return of(defaultTutor);
    }
    return of(foundTutor);
  }
}
