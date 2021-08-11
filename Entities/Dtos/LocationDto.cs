using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Entities.Database;
using NetTopologySuite.Geometries;

namespace Entities.Dtos {
    public class LocationDto {
        [Required]
        public double Latitude { get; set; }

        [Required]
        public double Longitude { get; set; }
    }
}