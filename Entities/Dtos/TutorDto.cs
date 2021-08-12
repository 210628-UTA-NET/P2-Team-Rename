using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using Entities.Database;
using NetTopologySuite.Geometries;

namespace Entities.Dtos {
    public class TutorDto : UserDto {
        public string About { get; set; }

        [Column(TypeName = "money")]
        public decimal? HourlyRate { get; set; }
        public double? Rating { get; set; }
        public double? Distance { get; set; }
        public ICollection<DegreeOrCertDto> DegreesOrCerts { get; set; }
        public ICollection<Topic> TutorTopics { get; set; }
        public ICollection<Review> TutorReviews { get; set; }
    }
}