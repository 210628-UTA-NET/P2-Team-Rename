import { TutorSearchV3Component } from './modules/user/components/tutor-search-v3/tutor-search-v3.component';
import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { AppRoutingModule } from './app-routing.module';
import { FontAwesomeModule } from '@fortawesome/angular-fontawesome';
import { NgbModule } from '@ng-bootstrap/ng-bootstrap';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
import { HttpClientModule } from '@angular/common/http';
import { JwtModule } from "@auth0/angular-jwt";

import { AppComponent } from './app.component';
import { HomeComponent } from './components/pages/home/home.component';
import { NavbarComponent } from './components/shared/navbar/navbar.component';
import { LoadingWheelComponent } from './components/shared/loading-wheel/loading-wheel.component';
import { AuthModule } from './modules/auth/auth.module';
import { AdminAdmitComponent } from './components/pages/admin-admit/admin-admit.component';
import { AdminAdmitCardComponent } from './components/pages/admin-admit-card/admin-admit-card.component';
import { UserListCardComponent } from './components/pages/user-list-card/user-list-card.component';
import { UserListComponent } from './components/pages/user-list/user-list.component';
import { UserModule } from './modules/user/user.module';
import { TutorApplyComponent } from './components/pages/tutor-apply/tutor-apply.component';
import { DashMainComponent } from './components/dashboard/dash-main/dash-main.component';
import { TutorDetailsComponent } from './modules/user/components/tutorDetails/tutorDetails.component';

export function tokenGetter() {
  return localStorage.getItem("token");
}

@NgModule({
  declarations: [
    AppComponent,
    HomeComponent,
    NavbarComponent,
    LoadingWheelComponent,
    AdminAdmitComponent,
    AdminAdmitCardComponent,
    UserListCardComponent,
    UserListComponent,
    TutorApplyComponent,
    LoadingWheelComponent,
    DashMainComponent,
    TutorDetailsComponent,
    TutorSearchV3Component

  ],
  imports: [
    BrowserModule,
    BrowserAnimationsModule,
    AppRoutingModule,
    FontAwesomeModule,
    NgbModule,
    ReactiveFormsModule,
    HttpClientModule,
    AuthModule,
    UserModule,
    FormsModule,
    JwtModule.forRoot({
      config: {
        tokenGetter: tokenGetter,
        authScheme: 'Bearer ',
        allowedDomains: ["localhost:44385", "tutorconnectapi.azurewebsites.net"],
        disallowedRoutes: []
      }
    })
  ],
  providers: [],
  bootstrap: [AppComponent]
})
export class AppModule { }
