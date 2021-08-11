import { Component, OnInit } from '@angular/core';
import { faBook, faBookMedical } from '@fortawesome/free-solid-svg-icons';
import { AuthenticationService } from 'src/app/services/authentication.service';

@Component({
  selector: 'app-navbar',
  templateUrl: './navbar.component.html',
  styleUrls: ['./navbar.component.scss']
})
export class NavbarComponent implements OnInit {
  public faBook = faBook;
  public isUserAuthenticated: boolean = false;

  constructor(public authService: AuthenticationService) { 
    this.authService.authChanged.subscribe(res =>{
      this.isUserAuthenticated = res;
    });
  }

  ngOnInit(): void {
    if (this.authService.isUserAuthenticated()) {
      this.authService.changeAuthState(true);
    }
  }

}
