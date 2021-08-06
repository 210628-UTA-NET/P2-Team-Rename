import { TutorCardComponent } from './components/tutor-card/tutor-card.component';
import { TutorSearchComponent } from './components/tutor-search/tutor-search.component';
import { Routes, RouterModule } from '@angular/router';
import { TutorMatchesComponent } from './components/tutor-matches/tutor-matches.component';

const routes: Routes = [
  { path: 'search', component: TutorSearchComponent },
  { path: 'matches', component: TutorMatchesComponent },
  { path: 'tutor', component: TutorCardComponent }
];

export const UserRoutes = RouterModule.forChild(routes);
