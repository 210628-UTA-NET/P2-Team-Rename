import { TutorCardComponent } from './components/pages/tutor-card/tutor-card.component';
import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { HomeComponent } from './components/pages/home/home.component';
import { TutorSearchComponent } from './components/pages/tutor-search/tutor-search.component';
import { LoadingWheelComponent } from './components/shared/loading-wheel/loading-wheel.component';
import { BrowserModule } from '@angular/platform-browser';

const routes: Routes = [
  //{path:"", component: LoadingWheelComponent},
  {path: "", loadChildren: ()=> import('./modules/chat/chat.module').then(m => m.ChatModule)},
  {path: "login", loadChildren:() => import('./modules/auth/auth.module').then(m => m.AuthModule)},
  {path: "home", component: HomeComponent},
  {path: "search", component: TutorSearchComponent},
  {path: "matches", component: TutorCardComponent}
];

@NgModule({
  imports: [
    RouterModule.forRoot(routes),
    BrowserModule
  ],
  exports: [RouterModule]
})
export class AppRoutingModule { }
