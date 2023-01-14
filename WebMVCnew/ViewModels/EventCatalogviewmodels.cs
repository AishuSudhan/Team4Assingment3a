using Microsoft.AspNetCore.Mvc.Rendering;
using WebMVCnew.webModels;

namespace WebMVCnew.ViewModels
{
    public class EventCatalogviewmodels
    {
        public IEnumerable<SelectListItem> Categories { get; set; }
        public IEnumerable<SelectListItem> Popularevents { get; set; }
        public IEnumerable<EventcatalogClass> Eventcatalogs { get; set; }
        public Paginationinfo paginationinfo { get; set; }
        public int? CategoriesFilterApplied { get; set; }
        public int? PopularEventsFilterApplied { get; set; }
    }
}
