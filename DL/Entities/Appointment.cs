using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace DL.Entities
{
    public class Appointment
    {
        public Appointment()
        {
            this.Users = new HashSet<User>();
        }
        [Key]
        public string AppointmentID { get; set; }
        public DateTime Date { get; set; }
        public virtual Transaction Transaction { get; set; }
        public virtual ICollection<User> Users { get; set; }
    }
}