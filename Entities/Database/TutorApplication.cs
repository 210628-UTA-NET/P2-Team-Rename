using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Entities.Database {
    public class TutorApplication {
        public TutorApplication() {
            DegreesOrCerts = new HashSet<DegreeCertification>();
            Topics = new HashSet<Topic>();
        }

        [Key]
        public string Id { get; set; }
        public User User { get; set; }
        public string UserId { get; set; }
        public string About { get; set; }
        public ICollection<DegreeCertification> DegreesOrCerts { get; set; }
        public bool Open { get; set; }
        public ICollection<Topic> Topics { get; set; }

        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public DateTime Timestamp { get; set; }
    }
}