using System.ComponentModel.DataAnnotations;

namespace DL.Entities
{
    public class Tutor
    {
        [Key]
        public string TutorID { get; set; }
        public decimal HourlyRate { get; set; }
        public User User { get; set; }
    }
}