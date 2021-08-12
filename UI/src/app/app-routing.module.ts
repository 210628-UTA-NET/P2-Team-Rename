import { TutorApplyComponent } from './components/pages/tutor-apply/tutor-apply.component';
import { NgModule, Component } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { HomeComponent } from './components/pages/home/home.component';
import { LoadingWheelComponent } from './components/shared/loading-wheel/loading-wheel.component';
import { BrowserModule } from '@angular/platform-browser';
import { AdminAdmitCardComponent } from './components/pages/admin-admit-card/admin-admit-card.component';
import { UserListCardComponent } from './components/pages/user-list-card/user-list-card.component';

const routes: Routes = [
  //{path:"", component: LoadingWheelComponent},
  {path: "", loadChildren: ()=> import('./modules/chat/chat.module').then(m => m.ChatModule)},
  {path: "login", loadChildren:() => import('./modules/auth/auth.module').then(m => m.AuthModule)},
  {path: "user", loadChildren:() => import('./modules/user/user.module').then(m => m.UserModule)},
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
