using NetTopologySuite.Geometries;
using System.ComponentModel.DataAnnotations;

namespace Entities.Query {
    public class UserParameters: PagedQueryParameters {
        public string Name { get; set; }
        public string Role { get; set; }
        public double? Latitude { get; set; }
        public double? Longitude { get; set; }
        public double? Distance { get; set; }
    }
}