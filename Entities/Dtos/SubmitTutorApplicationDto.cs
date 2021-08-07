using System.ComponentModel.DataAnnotations;
using Entities.Database;

namespace Entities.Dtos {
    public class SubmitTutorApplicationDto {
        [Required(ErrorMessage = "Information about yourself is required")]
        public string About {get; set;}
        public DegreeCertification[] Certifications { get; set; }
        public Topic[] Topics { get; set; }
    }
}