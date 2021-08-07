using System.ComponentModel.DataAnnotations;

namespace Entities.Database {
    public class Payment {
        [Key]
        public string Id { get; set; }
        public string CreditCard { get; set; }
        public User User { get; set; }

    }
}