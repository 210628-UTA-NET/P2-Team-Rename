using System.ComponentModel.DataAnnotations;

namespace Entities.Database {
    public class Location {
        [Key]
        public string Id { get; set; }
        public decimal Latitude { get; set; }
        public decimal Longitude { get; set; }
    }
}