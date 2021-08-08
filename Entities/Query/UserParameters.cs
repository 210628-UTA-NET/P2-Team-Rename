using NetTopologySuite.Geometries;
using System.ComponentModel.DataAnnotations;

namespace Entities.Query {
    public class UserParameters: PagedQueryParameters {
        public string Name { get; set; }
        public string Role { get; set; }
        public Point Location { get; set; }
        public double? Distance { get; set; }
    }
}