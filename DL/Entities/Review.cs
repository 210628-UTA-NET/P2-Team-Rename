using System.ComponentModel.DataAnnotations;

namespace DL.Entities {
    public class Review {
        [Key]
        public string Id { get; set; }
        public Tutor Tutor { get; set; }
        public int Rating { get; set; }
        public string Details { get; set; }
    }
}