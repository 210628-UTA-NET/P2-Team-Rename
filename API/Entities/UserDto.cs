using System.Collections.Generic;
using DL.Entities;

namespace API {
    public class UserDto {
        public string Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string UserName { get; set; }
        public ICollection<Topic> Topics { get; set; }
        public Tutor IsTutor { get; set; }
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