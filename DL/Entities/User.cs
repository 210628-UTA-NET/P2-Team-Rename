using Microsoft.AspNetCore.Identity;
using System.Collections.Generic;

namespace DL.Entities {
    public class User : IdentityUser {
        public User() {
            Appointments = new HashSet<Appointment>();
            Messages = new HashSet<Message>();
            Topics = new HashSet<string>();
            Tutors = new HashSet<Tutor>();
        }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public ICollection<string> Topics { get; set; }
        public Tutor IsTutor { get; set; }
        public virtual ICollection<Message> Messages { get; set; }
        public virtual Location Location { get; set; }
        public virtual ICollection<Appointment> Appointments { get; set; }
        public virtual ICollection<Review> Reviews { get; set; }
        public ICollection<Transaction> Transactions { get; set; }
        public ICollection<Tutor> Tutors { get; set; }
    }
}