using System.ComponentModel.DataAnnotations;

namespace Entities.Database {
    public class DegreeCertification {
        [Key]
        public string Id { get; set; }
        public string Title { get; set; }
        public string Details { get; set; }
    }
}