using System;
using System.Collections.Generic;

namespace DL.Entities
{
    public class Message
    {
        public Message()
        {
            this.Users = new HashSet<User>();
        }
        public string MessageID { get; set; }
        public string SenderID { get; set; }
        public string RecieverID { get; set; }
        public string MessageBody { get; set; }
        public DateTime TimeSent { get; set; }
        public virtual ICollection<User> Users { get; set; }
    }
}