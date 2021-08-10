import { Tutor } from './../../../../models/tutor/tutor';
import { UserService } from './../../../../services/user.service';
import { Component, OnInit } from '@angular/core';
import { ActivatedRoute } from '@angular/router';

@Component({
  selector: 'app-tutorDetails',
  templateUrl: './tutorDetails.component.html',
  styleUrls: ['./tutorDetails.component.scss']
})
export class TutorDetailsComponent implements OnInit {
  tutor: Tutor | undefined;

  constructor(
    private route: ActivatedRoute,
    private userService: UserService
  ) {}

  ngOnInit() {
    this.getTutor();
  }
  getTutor(): void {
    const id = this.route.snapshot.paramMap.get('id');
    if (id !== null)
    {
      this.userService.GetTutor(id)
      .subscribe(tutor => this.tutor = tutor);
      console.log(this.tutor);
    }

  }

}
