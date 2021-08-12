import { Tutor } from './../../../../models/tutor/tutor';
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
  queryString: string = '';

  constructor(
    private userService: UserService,
    private route: Router,
    private activatedRoute: ActivatedRoute
  ) {}
  searchForm = new FormGroup({
    topic: new FormControl(''),
  });
  ngOnInit(): void { }


  onSubmit() {
    this.route.navigate([], {
      relativeTo: this.activatedRoute,
      queryParams: { topic: this.searchForm.get('topic')?.value },
    });

    //only works for form controls one level deep may change so I get the query string from route later
    this.queryString = Object.keys(this.searchForm.value).map(key => [key, this.searchForm.get(key)?.value]).reduce((query, [key, value], idx, arr) => {
      query = query.concat(`${key}=${value}`);
        if (idx < arr.length - 1)
        {
          query.concat('&');
        }

      return query;
    }, '?');

    this.search();
    this.searchForm.reset();
  }
  search() {
    if (this.queryString !== null) {
      this.userService
        .SearchTutors(this.queryString)
        .subscribe((searchedTutors) => (this.searchedTutors = searchedTutors));
    }
    else
    {
      this.searchedTutors = [];
    }
  }
}
