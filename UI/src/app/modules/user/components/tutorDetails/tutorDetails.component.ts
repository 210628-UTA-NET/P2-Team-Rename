import { Appointment } from './../../../../models/tutor/appointment';
import { Tutor } from './../../../../models/tutor/tutor';
import { UserService } from './../../../../services/user.service';
import { Component, OnInit } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import { FormBuilder, FormGroup, FormArray, FormControl, Validators } from '@angular/forms';

@Component({
  selector: 'app-tutorDetails',
  templateUrl: './tutorDetails.component.html',
  styleUrls: ['./tutorDetails.component.scss']
})

export class TutorDetailsComponent implements OnInit {
  tutor: Tutor | undefined;
  tutorId: string | undefined;
  availableAppts: Appointment[] | undefined;

  constructor(
    private route: ActivatedRoute,
    private userService: UserService
  ) {}

  ngOnInit() {
    this.getTutor();
    //this.getAppointments();
  }
  getTutor(): void {
    const id = this.route.snapshot.paramMap.get('id');
    if (id !== null)
    {
      this.userService.GetTutor(id)
      .subscribe(tutor => {
        this.tutor = tutor
        this.getAppointments(tutor.Id);
      });
      console.log(this.tutor);
      console.log(this.availableAppts);
    }
  }
  getAppointments(tutorId: string): void {
    //const id = this.route.snapshot.paramMap.get('id');
    let query = `available=true&tutorId=${tutorId}`;
    this.userService.GetTutorAppointments(query)
    .subscribe(appts => this.availableAppts = appts);
  }
  book(appointmentID: string): void {
    this.userService.BookAppointment(appointmentID)
    .subscribe(bookedAppointment => {
      if (bookedAppointment.Id) {
        this.availableAppts?.splice(this.availableAppts.findIndex(appointment => appointment.Id === bookedAppointment.Id), 1);
      }
    })
  }

}
