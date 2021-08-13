import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { LoginComponent } from './components/login/login.component';
import { LoginUserComponent } from './components/login-user/login-user.component';
import { RegisterUserComponent } from './components/register-user/register-user.component';
import { RouterModule } from '@angular/router';
import { ReactiveFormsModule } from '@angular/forms';
import { NgbModule } from '@ng-bootstrap/ng-bootstrap';
import { HTTP_INTERCEPTORS } from '@angular/common/http';
import { ErrorHandlerService } from 'src/app/services/error-handler.service';


@NgModule({
  declarations: [
    LoginComponent,
    LoginUserComponent,
    RegisterUserComponent
  ],
  imports: [
    CommonModule,
    ReactiveFormsModule,
    NgbModule,
    RouterModule.forChild([
      { path: '', component: LoginComponent },
    ])
  ],
  providers: [
    {
      provide: HTTP_INTERCEPTORS,
      useClass: ErrorHandlerService,
      multi: true
    }
  ]
})
export class AuthModule { }
