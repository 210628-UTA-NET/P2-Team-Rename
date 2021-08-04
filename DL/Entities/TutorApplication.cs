using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DL.Entities {
    public class TutorApplication {
        [Key]
        public string Id { get; set; }
        public Tutor Tutor { get; set; }
        public string About { get; set; }
        public bool Open { get; set; }

        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public DateTime Timestamp { get; set; }
    }
}