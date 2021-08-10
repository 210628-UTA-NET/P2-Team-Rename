using Microsoft.AspNetCore.Identity;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using GeoAPI.Geometries;
using System.ComponentModel.DataAnnotations.Schema;
using NetTopologySuite.Geometries;

namespace Entities.Database {
    public class User : IdentityUser {
        public User() {
            Appointments = new HashSet<Appointment>();
            MessagesSent = new HashSet<Message>();
            MessagesReceived = new HashSet<Message>();
            Topics = new HashSet<Topic>();
            TransactionsSent = new HashSet<Transaction>();
            TransactionsReceived = new HashSet<Transaction>();
            MyContacts = new HashSet<User>();
        }

        [Key]
        public override string Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public virtual ICollection<Topic> Topics { get; set; }
        public virtual Point Location { get; set; }
        public virtual ICollection<Message> MessagesSent { get; set; }
        public virtual ICollection<Message> MessagesReceived { get; set; }
        public virtual ICollection<Appointment> Appointments { get; set; }
        public virtual ICollection<Review> Reviews { get; set; }
        public virtual ICollection<Transaction> TransactionsSent { get; set; }
        public virtual ICollection<Transaction> TransactionsReceived { get; set; }
        public virtual ICollection<User> MyContacts { get; set; }
    }
}