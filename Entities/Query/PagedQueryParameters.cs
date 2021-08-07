using System.ComponentModel.DataAnnotations;

namespace Entities.Query {
    public abstract class PagedQueryParameters {
        [Range(0, int.MaxValue)]
        public int PageNumber { get; set; } = 1;

        [Range(0, int.MaxValue)]
        public int PageSize { get; set; } = 20;
        public string OrderBy { get; set; }
    }
}