import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { HomeComponent } from './components/pages/home/home.component';
import { LoginComponent } from './components/pages/login/login.component';
import { TutorSearchComponent } from './components/pages/tutor-search/tutor-search.component';

const routes: Routes = [
  {path:"", component: LoginComponent},
  {path: "home", component: HomeComponent},
  {path: "search", component: TutorSearchComponent}
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
