using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Entities.Database {
    public class Message {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public string Id { get; set; }
        public User Sender { get; set; }

        [Required]
        public string SenderId { get; set; }
        public User Receiver { get; set; }

        [Required]
        public string ReceiverId { get; set; }
        public string SenderName { get; set; }
        public virtual string Body { get; set; }
        public DateTime TimeSent { get; set; }
    }
}