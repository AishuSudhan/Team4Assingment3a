namespace WebMVCnew.webModels
{
    public class Paginatedclass
    {
        public int Pagenumber { get; set; }
        public int PageSize { get; set; }
        public long Count { get; set; }
        public IEnumerable<EventcatalogClass> Data { get; set; }
    }
}
