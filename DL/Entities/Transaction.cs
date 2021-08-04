using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DL.Entities {
    public class Transaction {
        [Key]
        public string Id { get; set; }

        [Column(TypeName = "money")]
        public decimal Amount { get; set; }
        public DateTime Date { get; set; }
        public virtual Appointment Appointment { get; set; }
        public virtual string AppointmentId { get; set; }
        public User UserSent { get; set; }
        public User UserReceived { get; set; }
    }
}