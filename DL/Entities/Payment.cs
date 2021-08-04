using System.ComponentModel.DataAnnotations;

namespace DL.Entities {
    public class Payment {
        [Key]
        public string Id { get; set; }
        public string CreditCard { get; set; }
        public User User { get; set; }

    }
}