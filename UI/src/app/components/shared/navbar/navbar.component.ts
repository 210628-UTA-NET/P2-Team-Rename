import { Component, OnInit } from '@angular/core';
import { faBook, faBookMedical } from '@fortawesome/free-solid-svg-icons';
import { UserDto } from 'src/app/models/api/user-dto.model';
import { AuthenticationService } from 'src/app/services/authentication.service';

@Component({
  selector: 'app-navbar',
  templateUrl: './navbar.component.html',
  styleUrls: ['./navbar.component.scss']
})
export class NavbarComponent implements OnInit {
  public faBook = faBook;
  public isUserAuthenticated: boolean = false;
  public user: UserDto = {
    id: 'test',
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
      console.log("updated");
      this.user = res;
    });
  }

  ngOnInit(): void {
    if (this.authService.isUserAuthenticated()) {
      this.authService.changeAuthState(true);
    }
  }

}
