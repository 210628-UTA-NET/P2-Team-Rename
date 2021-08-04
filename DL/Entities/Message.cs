using System;
using System.Collections.Generic;

namespace DL.Entities {
    public class Message {
        public Message() {
            Users = new HashSet<User>();
        }
        public string Id { get; set; }
        public User Sender { get; set; }
        public User Reciever { get; set; }
        public string MessageBody { get; set; }
        public DateTime TimeSent { get; set; }
        public virtual ICollection<User> Users { get; set; }
    }
}