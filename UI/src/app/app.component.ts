import { Component } from '@angular/core';
import { NavigationCancel, NavigationEnd, NavigationError, NavigationStart,  Router, RouterEvent } from '@angular/router';
import { filter } from 'rxjs/operators';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.scss']
})
export class AppComponent {
  title = 'TutorConnect';
  loading: boolean;

  constructor(public router: Router) {
    this.loading = false;
    router.events.pipe(
      filter((e): e is RouterEvent => e instanceof RouterEvent)
    ).subscribe((e: RouterEvent) => {
      this.navigationInterceptor(e);
    });
  }

  navigationInterceptor(event: RouterEvent): void {
    if (event instanceof NavigationStart) {
      this.loading = true
      console.log("loading start");
    }
    if (event instanceof NavigationEnd) {
      this.loading = false;
      console.log("loading end1");
    }

    // Set loading state to false in both of the below events to hide the spinner in case a request fails
    if (event instanceof NavigationCancel) {
      this.loading = false;
      console.log("loading end2");
    }
    if (event instanceof NavigationError) {
      this.loading = false;
      console.log("loading end3");
    }
  }
}
