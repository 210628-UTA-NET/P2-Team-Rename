import { Component, OnInit, NgZone } from '@angular/core';
import { FormGroup, FormControl } from '@angular/forms';
import { ChatMessage } from 'src/app/models/chat/message.model';
import { ChatService } from 'src/app/services/chat.service';

@Component({
  selector: 'app-chat-window',
  templateUrl: './chat-window.component.html',
  styleUrls: ['./chat-window.component.scss']
})
export class ChatWindowComponent implements OnInit {
  yourId: string = "";
  messages = new Array<ChatMessage>();  
  connectionForm: FormGroup = new FormGroup({
    userIdA: new FormControl(''),
    userIdB: new FormControl('')
  });
  messageBody = new FormControl('');
  sessionString: string = '';

  constructor(private chatService: ChatService, private ngZone: NgZone) { 
    this.subscribeToEvents();
  }

  ngOnInit(): void {
  }

  public sendMessage(): void {
    if (this.messageBody.value != '') {
      var msg: ChatMessage = {
        senderId: this.connectionForm.get('userIdA')?.value,
        receiverId: this.connectionForm.get('userIdB')?.value,
        senderName: "test",
        body: this.messageBody.value,
        date: new Date(),
      }
      this.chatService.sendMessage(msg);
    }
    this.messageBody.reset(); 
  }

  private subscribeToEvents(): void {  
    this.chatService.messageReceived.subscribe((message: ChatMessage) => {  
      this.ngZone.run(() => {   
          this.messages.push(message);
          console.log("got message"); 
      });  
    });  
  }

  public openPrivateChat(connectionForm: any): void {
    const formValues = { ...connectionForm };
    this.chatService.joinChat(formValues.userIdA, formValues.userIdB);
    this.sessionString = `${formValues.userIdA} chatting with ${formValues.userIdB}`
  }

}
