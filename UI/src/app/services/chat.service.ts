import { EventEmitter, Injectable } from '@angular/core';  
import { HubConnection, HubConnectionBuilder } from '@aspnet/signalr';  
import { ChatMessage } from '../models/chat/message.model';

@Injectable({
  providedIn: 'root'
})
export class ChatService {

  constructor() { }
}
