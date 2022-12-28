using Microsoft.AspNetCore.Mvc.Rendering;
using WebMVCnew.webModels;

namespace WebMVCnew.Services
{
    public interface IEventCatalog
    {
        Task<eventcatalogClass> GetCatalogAsync(int pagenumber, int pagesize);
        Task<IEnumerable<SelectListItem>> PopulareventsAsync();
        Task<IEnumerable<SelectListItem>> GetCategoriesAsync();
    }
}
