using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Entities.Database;

namespace Entities.Dtos {
    public class SubmitTutorApplicationDto {
        [Required(ErrorMessage = "Information about yourself is required")]
        public string About {get; set;}
        public ICollection<DegreeOrCertDto> DegreesOrCerts { get; set; }
        public ICollection<Topic> Topics { get; set; }
    }
}