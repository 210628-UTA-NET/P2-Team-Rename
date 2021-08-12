import { ShareData } from './../../../../services/shareDataService';
import { Appointment } from './../../../../models/tutor/appointment';
import { Tutor } from './../../../../models/tutor/tutor';
import { UserService } from './../../../../services/user.service';
import { Component, HostListener, Input, OnInit, Type } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';

@Component({
  selector: 'app-tutorDetails',
  templateUrl: './tutorDetails.component.html',
  styleUrls: ['./tutorDetails.component.scss']
})

export class TutorDetailsComponent implements OnInit {
  tutor: Tutor | undefined;
  tutorId: string | undefined;
  availableAppts: Appointment[] | undefined;
  cityAndState: string | null = '';

  constructor(
    private activatedRoute: ActivatedRoute,
    private userService: UserService,
    private route: Router,
  ) { }

  ngOnInit() {
    this.getTutor();
    this.cityAndState = this.activatedRoute.snapshot.paramMap.get('cityAndState');
  }
  getTutor(): void {
    const id = this.activatedRoute.snapshot.paramMap.get('id');
    if (id !== null)
    {
      this.userService.GetTutor(id)
      .subscribe(tutor => {
        this.tutor = tutor
        this.getAppointments(tutor.id);
      });
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

  back(): void {
    this.route.navigate(['searchv3']);
  }

}
