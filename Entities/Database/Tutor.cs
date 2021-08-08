using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Entities.Database {
    public class Tutor: User {
        public Tutor() {
            DegreesOrCerts = new HashSet<DegreeCertification>();
            TutorReviews = new HashSet<Review>();
            TutorTopics = new HashSet<Topic>();
        }

        public string About {get; set;}

        [Column(TypeName = "money")]
        public decimal? HourlyRate { get; set; }
        public double? Rating { get; set; }
        public ICollection<DegreeCertification> DegreesOrCerts { get; set; }
        public ICollection<Topic> TutorTopics { get; set; }
        public ICollection<Review> TutorReviews { get; set; }
    }
}