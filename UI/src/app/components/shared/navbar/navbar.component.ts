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

  constructor(public authService: AuthenticationService) { }

  ngOnInit(): void {
    this.authService.authChanged.subscribe(res =>{
      this.isUserAuthenticated = res;
    });
  }

}
