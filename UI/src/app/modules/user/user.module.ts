import { UserRoutes } from './user.routing';
import { TutorSearchComponent } from './components/tutor-search/tutor-search.component';
import { TutorMatchesComponent } from './components/tutor-matches/tutor-matches.component';
import { TutorCardComponent } from './components/tutor-card/tutor-card.component';
import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';



@NgModule({
  declarations: [
    TutorCardComponent,
    TutorMatchesComponent,
    TutorSearchComponent
  ],
  imports: [
    CommonModule,
    UserRoutes
  ]
})
export class UserModule { }
