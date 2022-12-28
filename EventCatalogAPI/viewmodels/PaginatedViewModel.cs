using EventCatalogAPI.domain;

namespace EventCatalogAPI.viewmodels
{
    public class PaginatedViewModel
    {
        public int Pagenumber { get; set; }
        public int PageSize { get; set; }
        public long Count { get; set; }
        public IEnumerable<EventCatalog> Data { get; set; }
    }
}
