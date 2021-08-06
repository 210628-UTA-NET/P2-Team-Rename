import { TutorSearchV3Component } from './components/tutor-search-v3/tutor-search-v3.component';
import { TutorSearchV2Component } from './components/tutor-search-v2/tutor-search-v2.component';
import { TutorCardComponent } from './components/tutor-card/tutor-card.component';
import { TutorSearchComponent } from './components/tutor-search/tutor-search.component';
import { Routes, RouterModule } from '@angular/router';
import { TutorMatchesComponent } from './components/tutor-matches/tutor-matches.component';

const routes: Routes = [
  { path: 'search', component: TutorSearchComponent },
  { path: 'searchv2', component: TutorSearchV2Component },
  { path: 'searchv3', component: TutorSearchV3Component },
  { path: 'matches', component: TutorMatchesComponent },
  { path: 'tutor', component: TutorCardComponent }
];

export const UserRoutes = RouterModule.forChild(routes);
