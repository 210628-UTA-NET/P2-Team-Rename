using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace DL.Entities {
    public class Tutor {
        public Tutor() {
            DegreesOrCerts = new HashSet<DegreeCertification>();
            Reviews = new HashSet<Review>();
            Topics = new HashSet<Topic>();
        }

        [Key]
        public string Id { get; set; }
        public string About {get; set;}
        public decimal HourlyRate { get; set; }

        [Required]
        public User UserAccount { get; set; }
        public virtual string UserAccountId { get; set; }
        public ICollection<DegreeCertification> DegreesOrCerts { get; set; }
        public ICollection<Topic> Topics { get; set; }
        public ICollection<Review> Reviews { get; set; }
    }
}