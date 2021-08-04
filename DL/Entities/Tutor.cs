using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace DL.Entities {
    public class Tutor {
        public Tutor() {
            DegreesOrCerts = new HashSet<DegreeCertification>();
        }

        [Key]
        public string Id { get; set; }
        public decimal HourlyRate { get; set; }
        public User User { get; set; }
        public virtual string UserId { get; set; }
        public ICollection<DegreeCertification> DegreesOrCerts { get; set; }
    }
}