using System.ComponentModel.DataAnnotations;

namespace Entities.Query {
    public class TutorAppParameters: PagedQueryParameters {
        public bool Open {get; set;}
    }
}