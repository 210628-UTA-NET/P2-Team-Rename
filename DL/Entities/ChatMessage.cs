using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace DL.Entities {
    public class ChatMessage {
        [Key]
        public string Id { get; set; }
        public string SenderId { get; set; }
        public string ReceiverId { get; set; }
        public virtual User Sender { get; set; }
        public virtual User Receiver { get; set; }
        public string SenderName { get; set; }
        public string Body { get; set; }
        public DateTime TimeStamp { get; set; }
    }
}