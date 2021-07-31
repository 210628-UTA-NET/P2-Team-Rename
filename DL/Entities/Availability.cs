using System;
using System.ComponentModel.DataAnnotations;

namespace DL.Entities
{
    public class Availability
    {
        [Key]
        public string AvailabilityID { get; set; }
        public DateTime AvailabilityStart { get; set; }
        public DateTime AvailabilityEnd { get; set; }
        public virtual User User { get; set; }
    }
}