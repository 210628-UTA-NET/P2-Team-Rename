using Microsoft.AspNetCore.Identity;
using System.Collections.Generic;

namespace DL.Entities
{
    public class User : IdentityUser
    {
        public User()
        {
            this.Appointments = new HashSet<Appointment>();
            this.Messages = new HashSet<Message>();
            this.Topics = new HashSet<Topic>();
        }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public ICollection<Topic> Topics { get; set; }
        public Tutor Tutor { get; set; }
        public virtual ICollection<Message> Messages { get; set; }
        public virtual Location Location { get; set; }
        public virtual ICollection<Appointment> Appointments { get; set; }
        public virtual ICollection<Review> Reviews { get; set; }
        public ICollection<Transaction> Transactions { get; set; }
    }
}