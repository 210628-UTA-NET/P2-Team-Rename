using System.ComponentModel.DataAnnotations;

namespace DL.Entities {
    public class TutorApplication {
        [Key]
        public string Id { get; set; }
        public Tutor Tutor { get; set; }
        public string About { get; set; }
    }
}