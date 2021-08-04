using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace DL.Entities {
    public class Message {
        public Message() {
            Users = new HashSet<User>();
        }

        [Key]
        public string Id { get; set; }
        public string SenderId { get; set; }
        public string ReceiverId { get; set; }
        public User Sender { get; set; }
        public User Receiver { get; set; }
        public string MessageBody { get; set; }
        public DateTime TimeSent { get; set; }
        public virtual ICollection<User> Users { get; set; }
    }
}