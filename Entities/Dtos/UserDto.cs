using System.Collections.Generic;
using Entities.Database;
using NetTopologySuite.Geometries;

namespace Entities.Dtos {
    public class UserDto {
        public string Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string UserName { get; set; }
        public ICollection<Topic> Topics { get; set; }
        public Point Location { get; set; }
    }
}