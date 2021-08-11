import { EventEmitter, Injectable } from '@angular/core';  
import { HubConnection, HubConnectionBuilder } from '@aspnet/signalr';  
import { ChatMessage } from '../models/chat/message.model';
import { environment } from 'src/environments/environment';

@Injectable({
  providedIn: 'root'
})
export class ChatService {
  messageReceived = new EventEmitter<ChatMessage>();  
  connectionEstablished = new EventEmitter<Boolean>();  
  
  private _hubConnection: HubConnection;  
  
  constructor() {  
    this._hubConnection = new HubConnectionBuilder()  
      .withUrl(environment.urlAddress + '/chat')  
      .build();
    this.registerOnServerEvents();  
    this.startConnection();  
  }

  public sendMessage(message: ChatMessage) {  
    this._hubConnection.invoke('TestPrivateChat', message);  
  }
  
  public joinChat(senderId: string, receiverId: string) {
    if (this._hubConnection) {
      this._hubConnection.invoke('JoinPrivateChatTest', senderId, receiverId)
        .then(() => {
          console.log(`Connected to private chat with ${receiverId}.`)
        })
        .catch(err =>{
          console.log(err.toString());
        });
    }
  }

  public leaveChat(senderId: string, receiverId: string) {
    if (this._hubConnection) {
      this._hubConnection.invoke('LeavePrivateChatTest', senderId, receiverId)
        .then(() => {
          console.log(`Disconnected to private chat with ${receiverId}.`)
        })
        .catch(err =>{
          console.log(err.toString());
        });
    }
  }
  
  private startConnection(): void {  
    this._hubConnection  
      .start()  
      .then(() => {  
        console.log('Hub connection started');  
        this.connectionEstablished.emit(true);  
      })  
      .catch( _ => {  
        console.log('Error while establishing connection, retrying...');  
        setTimeout(() => this.startConnection(), 5000);  
      });  
  }
  
  private registerOnServerEvents(): void {  
    this._hubConnection.on('MessageReceived', (data: any) => {  
      console.log("message recieved");
      this.messageReceived.emit(data);  
    });  
  }  
}
