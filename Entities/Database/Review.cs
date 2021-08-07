using System.ComponentModel.DataAnnotations;

namespace Entities.Database {
    public class Review {
        [Key]
        public string Id { get; set; }
        public Tutor Tutor { get; set; }
        public int Rating { get; set; }
        public string Details { get; set; }
    }
}