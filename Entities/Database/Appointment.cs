using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Entities.Database {
    public class Appointment {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public string Id { get; set; }
        public DateTime Date { get; set; }
        public int MinuteLength { get; set; }
        public virtual Transaction Transaction { get; set; }
        public Tutor Tutor { get; set; }
        public string TutorId { get; set; }
        public User Student { get; set; }
        public string StudentId { get; set; }
    }
}