using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace DL.Entities {
    public class Topic {
        public Topic() {
            Users = new HashSet<User>();
        }
        [Key]
        public string TopicName { get; set; }
        public virtual ICollection<User> Users { get; set; }
    }
}