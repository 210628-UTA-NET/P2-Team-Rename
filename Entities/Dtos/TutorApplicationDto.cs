using System;
using System.Collections.Generic;
using Entities.Database;

namespace Entities.Dtos {
    public class TutorApplicationDto {
        public string Id { get; set; }
        public UserDto User { get; set; }
        public string About { get; set; }
        public ICollection<DegreeOrCertDto> DegreesOrCerts { get; set; }
        public bool Open { get; set; }
        public ICollection<string> Topics { get; set; }
        public DateTime Timestamp { get; set; }
    }
}