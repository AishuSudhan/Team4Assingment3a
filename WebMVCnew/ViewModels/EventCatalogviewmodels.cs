using Microsoft.AspNetCore.Mvc.Rendering;
using WebMVCnew.webModels;

namespace WebMVCnew.ViewModels
{
    public class EventCatalogviewmodels
    {
        public IEnumerable<SelectListItem> categories { get; set; }
        public IEnumerable<SelectListItem> popularevents { get; set; }
        public IEnumerable<eventcatalogClass> eventcatalogs { get; set; }
        public Paginatedclass paginatedclass { get; set; }
    }
}
