using System.ComponentModel.DataAnnotations;

namespace Entities.Query {
    public class AppointmentParameters: PagedQueryParameters {
        public string TutorId { get; set; }
        public string StudentId { get; set; }
        public string UserId { get; set; }
        public bool Available {get; set;}
    }
}