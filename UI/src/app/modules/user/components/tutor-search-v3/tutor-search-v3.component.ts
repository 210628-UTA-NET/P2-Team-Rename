import { Tutor } from './../../../../models/tutor/tutor';
import { Location } from '@angular/common';
import { Router, ActivatedRoute } from '@angular/router';
import { UserService } from './../../../../services/user.service';
import { Component, OnInit } from '@angular/core';
import { FormControl, FormGroup } from '@angular/forms';

@Component({
  selector: 'app-tutor-search-v3',
  templateUrl: './tutor-search-v3.component.html',
  styleUrls: ['./tutor-search-v3.component.scss'],
})
export class TutorSearchV3Component implements OnInit {
  searchedTutors: Tutor[] = [];

  constructor(
    private userService: UserService,
    private route: Router,
    private location: Location,
    private activatedRoute: ActivatedRoute
  ) {}
  searchForm = new FormGroup({
    topic: new FormControl(''),
  });
  ngOnInit(): void {}

  onSubmit() {
    this.route.navigate([], {
      relativeTo: this.activatedRoute,
      queryParams: { topic: this.searchForm.get('topic')?.value },
    });
    this.search(this.searchForm.get('topic')?.value);
    this.searchForm.reset();
  }
  search(searchTerm: string) {
    if (searchTerm !== null) {
      this.userService
        .SearchTutors(searchTerm)
        .subscribe((searchedTutors) => (this.searchedTutors = searchedTutors));
    }
    else
    {
      this.searchedTutors = [];
    }
  }
}
