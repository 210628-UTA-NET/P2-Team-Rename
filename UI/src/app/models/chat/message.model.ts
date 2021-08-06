export interface ChatMessage {
  SenderId: string;
  ReceiverId: string;
  SenderName: string;
  Body: string;
  Date: Date;
}