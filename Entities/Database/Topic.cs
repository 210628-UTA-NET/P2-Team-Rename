using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Entities.Database {
    public class Topic {

        [Key]
        public string TopicName { get; set; }
    }
}