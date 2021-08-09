using System.ComponentModel.DataAnnotations;

namespace Entities.Dtos {
    public class DegreeOrCertDto {
        [Required]
        public string Title { get; set; }
        public string Details { get; set; }
    }
}