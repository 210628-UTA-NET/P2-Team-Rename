import { Component, OnInit } from '@angular/core';
import { faBook, faBookMedical, faUser } from '@fortawesome/free-solid-svg-icons';
import { UserDto } from 'src/app/models/api/user-dto.model';
import { AuthenticationService } from 'src/app/services/authentication.service';

@Component({
  selector: 'app-navbar',
  templateUrl: './navbar.component.html',
  styleUrls: ['./navbar.component.scss']
})
export class NavbarComponent implements OnInit {
  public faBook = faBook;
  public userIcon = faUser;

  public role = "User";
  public isUserAuthenticated: boolean = false;
  public user: UserDto = {
    id: '',
    firstName: '',
    lastName: '',
    email: '',
    userName: '',
    topics:  null,
    location: null,
  };

  constructor(public authService: AuthenticationService) { 
    this.authService.authChanged.subscribe(res =>{
      this.isUserAuthenticated = res;
    });

    this.authService.userInfo.subscribe(res => {
      this.user = res;
    });

    this.authService.userRole.subscribe(res => {
      this.role = res;
    });
  }

  ngOnInit(): void {
    if (this.authService.isUserAuthenticated()) {
      this.authService.changeAuthState(true);
    }
  }

}
