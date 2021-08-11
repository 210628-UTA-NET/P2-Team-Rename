using System.ComponentModel.DataAnnotations;


namespace Entities.Dtos {
    public class LocationDto {
        [Required]
        public double Latitude { get; set; }

        [Required]
        public double Longitude { get; set; }
    }
}