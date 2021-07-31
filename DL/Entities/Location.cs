using System.ComponentModel.DataAnnotations;

namespace DL.Entities
{
    public class Location
    {
        [Key]
        public string LocationID { get; set; }
        public decimal Latitude { get; set; }
        public decimal Longitude { get; set; }
        public User User { get; set; }
    }
}