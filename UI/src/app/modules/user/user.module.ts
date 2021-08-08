import { UserRoutes } from './user.routing';
import { TutorSearchComponent } from './components/tutor-search/tutor-search.component';
import { TutorMatchesComponent } from './components/tutor-matches/tutor-matches.component';
import { TutorCardComponent } from './components/tutor-card/tutor-card.component';
import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { TutorSearchV2Component } from './components/tutor-search-v2/tutor-search-v2.component';
import { TutorSearchV3Component } from './components/tutor-search-v3/tutor-search-v3.component';



@NgModule({
  declarations: [
    TutorCardComponent,
    TutorMatchesComponent,
    TutorSearchComponent,
    TutorSearchV2Component,
    TutorSearchV3Component
  ],
  imports: [
    CommonModule,
    UserRoutes
  ]
})
export class UserModule { }
