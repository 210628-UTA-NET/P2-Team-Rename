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
  @Input() tutor?: Tutor;
  tutorId: string | undefined;
  availableAppts: Appointment[] | undefined;
  cityAndState: string | null = '';

  constructor(
    private activatedRoute: ActivatedRoute,
    private userService: UserService,
    private route: Router,
  ) { }

  ngOnInit() {
    /*this.getTutor();
    this.cityAndState = this.activatedRoute.snapshot.paramMap.get('cityAndState');*/
    this.getAppointments(this.tutor?.id);
    console.log(this.availableAppts);
  }
  /*getTutor(): void {
    const id = this.activatedRoute.snapshot.paramMap.get('id');
    if (id !== null)
    {
      this.userService.GetTutor(id)
      .subscribe(tutor => {
        this.tutor = tutor
        this.getAppointments(tutor.id);
      });
    }
  }*/
  getAppointments(tutorId: string | undefined): void {
    //const id = this.route.snapshot.paramMap.get('id');
    console.log('tutor ID ' +tutorId);
    let query = `available=true&tutorId=${tutorId}`;
    this.userService.GetTutorAppointments(query)
    .subscribe(appts => {
      console.log("retrieved appts");
      console.log(appts);
      this.availableAppts = appts});
  }
  book(appointmentID: string): void {
    this.userService.BookAppointment(appointmentID)
    .subscribe(bookedAppointment => {
      if (bookedAppointment.id) {
        this.availableAppts?.splice(this.availableAppts.findIndex(appointment => appointment.id === bookedAppointment.id), 1);
      }
    })
  }

  back(): void {
    this.tutor = undefined;
  }

}
