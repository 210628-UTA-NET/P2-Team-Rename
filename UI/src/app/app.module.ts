import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';
import { ReactiveFormsModule } from '@angular/forms';
import { AppRoutingModule } from './app-routing.module';
import { FontAwesomeModule } from '@fortawesome/angular-fontawesome';
import { NgbModule } from '@ng-bootstrap/ng-bootstrap';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
import { HttpClientModule } from '@angular/common/http';
import { JwtModule } from "@auth0/angular-jwt";

import { AppComponent } from './app.component';
import { HomeComponent } from './components/pages/home/home.component';
import { NavbarComponent } from './components/shared/navbar/navbar.component';
import { AuthenticationService } from './services/authentication.service';
import { TutorSearchComponent } from './components/pages/tutor-search/tutor-search.component';
import { TutorMatchesComponent } from './components/pages/tutor-matches/tutor-matches.component';
import { TutorCardComponent } from './components/pages/tutor-card/tutor-card.component';
import { LoadingWheelComponent } from './components/shared/loading-wheel/loading-wheel.component';
import { AuthModule } from './modules/auth/auth.module';
import { AdminAdmitComponent } from './components/pages/admin-admit/admin-admit.component';
import { AdminAdmitCardComponent } from './components/pages/admin-admit-card/admin-admit-card.component';
import { UserListCardComponent } from './components/pages/user-list-card/user-list-card.component';
import { UserListComponent } from './components/pages/user-list/user-list.component';

export function tokenGetter() {
  return localStorage.getItem("token");
}

@NgModule({
  declarations: [
    AppComponent,
    HomeComponent,
    NavbarComponent,
    TutorSearchComponent,
    TutorMatchesComponent,
    TutorCardComponent,
    LoadingWheelComponent,
    AdminAdmitComponent,
    AdminAdmitCardComponent,
    UserListCardComponent,
    UserListComponent
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
    JwtModule.forRoot({
      config: {
        tokenGetter: tokenGetter,
        allowedDomains: ["localhost:44329"],
        disallowedRoutes: []
      }
    })
  ],
  providers: [AuthenticationService],
  bootstrap: [AppComponent]
})
export class AppModule { }
