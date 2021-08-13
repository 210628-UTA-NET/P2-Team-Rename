import { Tutor } from './../../../../models/tutor/tutor';
import { Router, ActivatedRoute } from '@angular/router';
import { UserService } from './../../../../services/user.service';
import { Component, OnInit } from '@angular/core';
import { FormControl, FormGroup } from '@angular/forms';
import { ShareData } from 'src/app/services/shareDataService';

@Component({
  selector: 'app-tutor-search-v3',
  templateUrl: './tutor-search-v3.component.html',
  styleUrls: ['./tutor-search-v3.component.scss'],
})
export class TutorSearchV3Component implements OnInit {
  searchedTutors: Tutor[] = [];
  queryString: string = '';
  cityAndState: string[] = [];
  orderBy = [
    {name: 'Price', abbrev: 'Price'},
    {name: 'Rating_desc', abbrev: 'Rating'}
  ];
  sortOption: string = this.orderBy[1].name;
  searchForm = new FormGroup({
    topic: new FormControl(''),
  });
  selectedTutor: Tutor | undefined;

  constructor(
    private userService: UserService,
    private route: Router,
    private activatedRoute: ActivatedRoute,
    private shareData: ShareData
  ) {}


  ngOnInit(): void {

  }

  onSubmit() {
    /*this.route.navigate([], {
      relativeTo: this.activatedRoute,
      queryParams: { topic: `${this.searchForm.get('topic')?.value}` },
    });*/

    //only works for form controls one level deep may change so I get the query string from route later
    this.setQueryString();

    this.search(`${this.queryString}&orderBy=${this.sortOption}`);
    this.searchForm.reset();
  }
  setQueryString(): void {
    this.queryString = Object.keys(this.searchForm.value)
      .map((key) => [key, this.searchForm.get(key)?.value])
      .reduce((query, [key, value], idx, arr) => {
        query = query.concat(`${key}=${value}`);
        if (idx < arr.length - 1) {
          query.concat('&');
        }

        return query;
      }, '?');
  }
  search(queryString: string) {
    if (this.queryString !== null) {
      this.userService
        .SearchTutors(queryString)
        .subscribe((searchedTutors) => {
          let {results} = searchedTutors;
          this.searchedTutors = results
        });
    } else {
      this.searchedTutors = [];
    }

    /*this.searchedTutors
      .map((tutor) => tutor.Location)
      .forEach((location, index) => {
        this.locationService.GetCityState(location).subscribe((resp) => {
          let label = resp.data[0].label.split(',').slice(1).join();
          this.cityAndState[index] = label;
        });
      });*/
  }


  sort(criteria: any) {
    this.sortOption = criteria;
    /*this.route.navigate([], {
      relativeTo: this.activatedRoute,
      queryParams: {
        orderBy: criteria
      },
      queryParamsHandling: 'merge'
    });*/
    this.search(`${this.queryString}&OrderBy=${criteria}`)
  }
  select(tutor: Tutor) {
    console.log('clicked');
    this.selectedTutor = tutor;
  }
  back(): void {
    this.selectedTutor = undefined;
    this.searchedTutors = [];
  }
}
