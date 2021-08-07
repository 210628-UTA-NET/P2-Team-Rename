using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Entities.Database {
    public class Appointment {
        public Appointment() {
            Users = new HashSet<User>();
        }
        [Key]
        public string Id { get; set; }
        public DateTime Date { get; set; }
        public virtual Transaction Transaction { get; set; }
        public virtual ICollection<User> Users { get; set; }
    }
}