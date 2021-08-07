using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Entities.Database {
    public class Tutor: User {
        public Tutor() {
            DegreesOrCerts = new HashSet<DegreeCertification>();
            Reviews = new HashSet<Review>();
            Topics = new HashSet<Topic>();
        }

        public string About {get; set;}

        [Column(TypeName = "money")]
        public decimal HourlyRate { get; set; }
        public ICollection<DegreeCertification> DegreesOrCerts { get; set; }
        public ICollection<Topic> TutorTopics { get; set; }
        public ICollection<Review> TutorReviews { get; set; }
    }
}