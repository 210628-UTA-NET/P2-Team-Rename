import { HttpClient } from '@angular/common/http';
import { Component, ElementRef, NgZone, OnInit, ViewChild } from '@angular/core';
import { UserDto } from 'src/app/models/api/user-dto.model';
import { UserContactResponse } from 'src/app/models/user/user-contacts-response.model';
import { AuthenticationService } from 'src/app/services/authentication.service';
import { environment } from 'src/environments/environment';
import {NgbModal, ModalDismissReasons} from '@ng-bootstrap/ng-bootstrap';
import { FormControl } from '@angular/forms';
import { ChatService } from 'src/app/services/chat.service';
import { ChatMessage } from 'src/app/models/chat/message.model';

@Component({
  selector: 'app-dash-main',
  templateUrl: './dash-main.component.html',
  styleUrls: ['./dash-main.component.scss']
})
export class DashMainComponent implements OnInit {
  public contacts: UserDto[] = [];
  public chatTarget: UserDto;
  public messageBody = new FormControl('');
  public messages: ChatMessage[] = [];
  public user: UserDto;

  constructor(
    private http: HttpClient, 
    public authService: AuthenticationService, 
    private modalService: NgbModal,
    private chatService: ChatService, 
    private ngZone: NgZone){ 

    if (authService.isUserAuthenticated()) {
      this.getUserContacts();
    }
    this.subscribeToEvents();

    this.authService.userInfo.subscribe(res => {
      this.user = res;
    });
  }

  ngOnInit(): void {
  }

  public getUserContacts() {
    this.http.get<UserContactResponse>(`${environment.urlAddress}/user/contacts`).subscribe(res => {
      console.log(res.results);
      this.contacts = res.results;
    });
  }

  public openPrivateChat(target: UserDto, content: any) {
    console.log(target.id);
    this.chatTarget = target;
    this.modalService.open(content, { 
      centered: true,
      scrollable: true
    }).result.then( _ => {
      this.chatService.leaveChat(target.id);
      this.messages = [];
    }, _ => {
      this.chatService.leaveChat(target.id);
      this.messages = [];
    })
    this.chatService.joinChat(target.id);
  }

  public sendMessage() {
    if (this.messageBody.value != '') {
      var msg: ChatMessage = {
        senderId: this.user.id,
        receiverId: this.chatTarget.id,
        senderName: `${this.user.firstName} ${this.user.lastName}`,
        body: this.messageBody.value,
        timeSent: new Date(),
      }
      this.chatService.sendMessage(msg);
    }
    this.messageBody.reset(); 
  }

  private subscribeToEvents(): void {  
    this.chatService.messageReceived.subscribe((message: ChatMessage) => {  
      this.ngZone.run(() => {   
          this.messages.push(message);
      });  
    });  
  }
}
