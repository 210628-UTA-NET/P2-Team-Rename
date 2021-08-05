using Microsoft.AspNetCore.Identity;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.ComponentModel.DataAnnotations;

namespace DL.Entities {

    [DataContract]
    public class User : IdentityUser {
        public User() {
            Appointments = new HashSet<Appointment>();
            MessagesSent = new HashSet<Message>();
            MessagesReceived = new HashSet<Message>();
            Topics = new HashSet<Topic>();
            Tutors = new HashSet<Tutor>();
            TransactionsSent = new HashSet<Transaction>();
            TransactionsReceived = new HashSet<Transaction>();
        }

        [Key]
        public override string Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public ICollection<Topic> Topics { get; set; }
        public Tutor IsTutor { get; set; }
        public virtual ICollection<ChatMessage> ChatMessages { get; set; }
        public virtual ICollection<Message> MessagesSent { get; set; }
        public virtual ICollection<Message> MessagesReceived { get; set; }
        public virtual Location Location { get; set; }
        public virtual ICollection<Appointment> Appointments { get; set; }
        public virtual ICollection<Review> Reviews { get; set; }
        public ICollection<Transaction> TransactionsSent { get; set; }
        public ICollection<Transaction> TransactionsReceived { get; set; }
        public ICollection<Tutor> Tutors { get; set; }
    }
}