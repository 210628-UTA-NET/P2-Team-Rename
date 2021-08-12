import { Tutor } from './../../../../models/tutor/tutor';
import { Router, ActivatedRoute } from '@angular/router';
import { UserService } from './../../../../services/user.service';
import { Component, OnInit } from '@angular/core';
import { FormControl, FormGroup } from '@angular/forms';
import { LocationService } from 'src/app/services/location.service';
import { ShareData } from 'src/app/services/shareDataService';
import { FormsModule } from '@angular/forms';

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

  constructor(
    private userService: UserService,
    private locationService: LocationService,
    private route: Router,
    private activatedRoute: ActivatedRoute,
    private shareData: ShareData
  ) {}
  searchForm = new FormGroup({
    topic: new FormControl(''),
  });

  ngOnInit(): void {

  }

  onSubmit() {
    this.route.navigate([], {
      relativeTo: this.activatedRoute,
      queryParams: { topic: `${this.searchForm.get('topic')?.value}` },
    });

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
        .subscribe((searchedTutors) => (this.searchedTutors = searchedTutors));
    } else {
      this.searchedTutors = [];
    }

    this.searchedTutors
      .map((tutor) => tutor.Location)
      .forEach((location, index) => {
        this.locationService.GetCityState(location).subscribe((resp) => {
          let label = resp.data[0].label.split(',').slice(1).join();
          this.cityAndState[index] = label;
        });
      });
  }


  sort(criteria: any) {
    this.sortOption = criteria;
    this.route.navigate([], {
      relativeTo: this.activatedRoute,
      queryParams: {
        orderBy: criteria
      },
      queryParamsHandling: 'merge',
      // preserve the existing query params in the route
      //skipLocationChange: true
      // do not trigger navigation
    });
    console.log(criteria);
    this.search(`${this.queryString}&OrderBy=${criteria}`)
    console.log(this.searchedTutors);
    //console.log(`${this.queryString}&orderBy=${criteria}`);
  }
}
