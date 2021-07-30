using System.ComponentModel.DataAnnotations;

namespace DL.Entities
{
    public class Review
    {
        [Key]
        public string ReviewID { get; set; }
        public int Rating { get; set; }
        public string Details { get; set; }
    }
}