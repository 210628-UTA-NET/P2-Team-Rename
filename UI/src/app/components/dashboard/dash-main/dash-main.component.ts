import { HttpClient } from '@angular/common/http';
import { Component, OnInit } from '@angular/core';
import { UserDto } from 'src/app/models/api/user-dto.model';
import { UserContactResponse } from 'src/app/models/user/user-contacts-response.model';
import { AuthenticationService } from 'src/app/services/authentication.service';
import { environment } from 'src/environments/environment';
import {NgbModal, ModalDismissReasons} from '@ng-bootstrap/ng-bootstrap';
import { FormControl } from '@angular/forms';

@Component({
  selector: 'app-dash-main',
  templateUrl: './dash-main.component.html',
  styleUrls: ['./dash-main.component.scss']
})
export class DashMainComponent implements OnInit {
  public contacts: UserDto[] = [];
  public chatTarget: UserDto;
  public messageBody = new FormControl('');

  constructor(private http: HttpClient, authService: AuthenticationService, private modalService: NgbModal) { 
    if (authService.isUserAuthenticated()) {
      this.getUserContacts();
    }
  }

  ngOnInit(): void {}

  public getUserContacts() {
    this.http.get<UserContactResponse>(`${environment.urlAddress}/user/contacts`).subscribe(res => {
      console.log("got contacts");
      this.contacts = res.results;
    });
  }

  public openPrivateChat(target: UserDto, content: any) {
    console.log(target.id);
    this.chatTarget = target;
    this.modalService.open(content, { 
      centered: true,
      scrollable: true
    });
  }

  public sendMessage() {
    if (this.messageBody.value != '') {
      console.log(this.messageBody.value);
    }
    this.messageBody.reset(); 
  }
}
