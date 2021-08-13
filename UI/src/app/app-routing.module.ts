import { TutorSearchV3Component } from './modules/user/components/tutor-search-v3/tutor-search-v3.component';
import { TutorApplyComponent } from './components/pages/tutor-apply/tutor-apply.component';
import { NgModule, Component } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { HomeComponent } from './components/pages/home/home.component';
import { LoadingWheelComponent } from './components/shared/loading-wheel/loading-wheel.component';
import { BrowserModule } from '@angular/platform-browser';
import { AdminAdmitCardComponent } from './components/pages/admin-admit-card/admin-admit-card.component';
import { UserListCardComponent } from './components/pages/user-list-card/user-list-card.component';
import { DashMainComponent } from './components/dashboard/dash-main/dash-main.component';
import { UserGuard } from './guards/user.guard';
import { TutorDetailsComponent } from './modules/user/components/tutorDetails/tutorDetails.component';

const routes: Routes = [
  //{path:"", component: LoadingWheelComponent},
  //{path: "", loadChildren: ()=> import('./modules/chat/chat.module').then(m => m.ChatModule)},
  {path: "", component: DashMainComponent, canActivate: [UserGuard] },
  {path: "login", loadChildren:() => import('./modules/auth/auth.module').then(m => m.AuthModule)},
  //{path: "user", loadChildren:() => import('./modules/user/user.module').then(m => m.UserModule)},
  {path: "searchv3", component: TutorSearchV3Component},
  {path: "tutor/:id/:cityAndState", component: TutorDetailsComponent},
  {path: "home", component: HomeComponent},
  {path: "admit", component: AdminAdmitCardComponent},
  {path: "userlist", component: UserListCardComponent},
  {path: "tutorapply", component: TutorApplyComponent},
];

@NgModule({
  imports: [
    RouterModule.forRoot(routes),
    BrowserModule
  ],
  exports: [RouterModule]
})
export class AppRoutingModule { }
