import { Component, OnInit } from '@angular/core';
import { faBook, faBookMedical } from '@fortawesome/free-solid-svg-icons';
import { AuthenticationService } from 'src/app/services/authentication.service';

@Component({
  selector: 'app-navbar',
  templateUrl: './navbar.component.html',
  styleUrls: ['./navbar.component.scss']
})
export class NavbarComponent implements OnInit {
  faBook = faBook;

  constructor(private authService: AuthenticationService) { }

  ngOnInit(): void {
  }

}
