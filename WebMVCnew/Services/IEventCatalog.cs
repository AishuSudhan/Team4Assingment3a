using Microsoft.AspNetCore.Mvc.Rendering;
using WebMVCnew.webModels;

namespace WebMVCnew.Services
{
    public interface IEventCatalog
    {
        Task<Paginatedclass> GetCatalogAsync(int pagenumber, int pagesize,int? popularevents,int? categories);
        Task<IEnumerable<SelectListItem>> PopulareventsAsync();
        Task<IEnumerable<SelectListItem>> GetCategoriesAsync();
    }
}
