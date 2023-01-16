using Microsoft.AspNetCore.Mvc;
using WebMVCnew.Services;
using WebMVCnew.ViewModels;
//using WebMVCnew.webModels;


namespace WebMVCnew.controller
{
    public class EventCatalogController : Controller
    {
        private readonly IEventCatalog _evtcatalog;
        public EventCatalogController(IEventCatalog evtCatalog)
        {
            _evtcatalog = evtCatalog;
        }
        public async Task<IActionResult> Index(int? pageNumber,int? popularEventsFilterApplied,int? categoriesFilterApplied)
        {
             var itemsonpage = 10;
           var eventcatalog= await _evtcatalog.GetCatalogAsync(pageNumber ?? 0, itemsonpage, popularEventsFilterApplied, categoriesFilterApplied);
           
             var catalogviewmodel = new EventCatalogviewmodels
            {
                Categories = await _evtcatalog.GetCategoriesAsync(),
                Popularevents = await _evtcatalog.PopulareventsAsync(),
                Eventcatalogs = eventcatalog.Data,
                PaginationInfo = new Paginationinfo
                {
                    ActualPage = eventcatalog.Pagenumber,
                    ItemsPerPage = eventcatalog.PageSize,
                    TotalItems = eventcatalog.Count,
                    TotalPages = (int)Math.Ceiling((decimal)eventcatalog.Count / itemsonpage)
                },
                 CategoriesFilterApplied = categoriesFilterApplied,
                 PopularEventsFilterApplied = popularEventsFilterApplied

            };
            return View(catalogviewmodel);
        }
    }
}
