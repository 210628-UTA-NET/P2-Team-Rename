using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Entities.Database {
    public class Topic {
        public Topic() {
            Users = new HashSet<User>();
        }
        [Key]
        public string TopicName { get; set; }
        public virtual ICollection<User> Users { get; set; }
    }
}