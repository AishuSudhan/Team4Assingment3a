using Microsoft.AspNetCore.Mvc;
using WebMVCnew.Services;
using WebMVCnew.ViewModels;
using WebMVCnew.webModels;

namespace WebMVCnew.controller
{
    public class EventCatalogController : Controller
    {
        private readonly IEventCatalog _evtcatalog;
        public EventCatalogController(IEventCatalog evtCatalog)
        {
            _evtcatalog = evtCatalog;
        }
        public async Task<IActionResult> Index(int? pagenumber)
        {
            var itemsonpage = 10;
           var eventcatalog= await _evtcatalog.GetCatalogAsync(pagenumber ?? 0, itemsonpage);
            var catalogviewmodel = new EventCatalogviewmodels
            {
                categories = await _evtcatalog.GetCategoriesAsync(),
                popularevents = await _evtcatalog.PopulareventsAsync(),
                eventcatalogs = eventcatalog.Data,
                paginationinfo = new Paginationinfo
                {
                    ActualPage = eventcatalog.Pagenumber,
                    ItemsPerPage = eventcatalog.PageSize,
                    TotalItems = eventcatalog.Count,
                    TotalPages = (int)Math.Ceiling((decimal)eventcatalog.Count / itemsonpage)
                }

            };
            return View();
        }
    }
}
