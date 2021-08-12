import { Appointment } from './../../../../models/tutor/appointment';
import { Tutor } from './../../../../models/tutor/tutor';
import { UserService } from './../../../../services/user.service';
import { Component, HostListener, OnInit, Type } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
import { FormBuilder, FormGroup, FormArray, FormControl, Validators } from '@angular/forms';
import { Location } from '@angular/common';
import { NgbActiveModal, NgbModal } from '@ng-bootstrap/ng-bootstrap';

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
    private activatedRoute: ActivatedRoute,
    private userService: UserService,
    private location: Location,
    private route: Router
  ) { }

  ngOnInit() {
    this.getTutor();
    //this.getAppointments();
  }
  getTutor(): void {
    const id = this.activatedRoute.snapshot.paramMap.get('id');
    if (id !== null)
    {
      this.userService.GetTutor(id)
      .subscribe(tutor => {
        this.tutor = tutor
        this.getAppointments(tutor.Id);
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
