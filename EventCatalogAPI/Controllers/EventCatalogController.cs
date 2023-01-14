using EventCatalogAPI.Data;
using EventCatalogAPI.domain;
using EventCatalogAPI.viewmodels;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace EventCatalogAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EventCatalogController : ControllerBase
    {
        private readonly EventCatalogContext _eventCatalogContext;
        private readonly IConfiguration _config;
        public EventCatalogController(EventCatalogContext eventCatalogContext,IConfiguration config)
        {
            _eventCatalogContext = eventCatalogContext;
            _config = config;
        }
        [HttpGet("[action]")]
        public async Task<IActionResult> Getcategories()
        {
           var category=await _eventCatalogContext.EventCatagories.ToListAsync();
            return Ok(category);
        }
        [HttpGet("[action]")]
        public async Task<IActionResult> GetpopularEvents()
        {
          var popularevents=await  _eventCatalogContext.PopularEvents.ToListAsync();
            return Ok(popularevents);
        }
        [HttpGet("[action]")]
        public async Task<IActionResult> Getcatalog([FromQuery]int pagenumber=0,[FromQuery]int pagesize=3)
        {
            var itemcount = _eventCatalogContext.EventCatalogs.LongCountAsync();

            var item = await _eventCatalogContext.EventCatalogs.OrderBy(i => i.Name)
                .Skip(pagenumber * pagesize).Take(pagesize).ToListAsync();
            item = Changepictureurl(item);

            var items = new PaginatedViewModel
            {
                Pagenumber = pagenumber,
                PageSize = pagesize,
                Data = item,
                Count = itemcount.Result
            };
            return Ok(items);

        }


        [HttpGet("[action]/filter")]
        public async Task<IActionResult> Getcatalog(
            [FromQuery] int? populareventid, [FromQuery] int? eventcategoryid,
             [FromQuery] int pagenumber = 0, [FromQuery] int pagesize = 3)
            
        {
            var query = (IQueryable<EventCatalog>)_eventCatalogContext.EventCatalogs;
            if(eventcategoryid.HasValue)
            {
                query = query.Where(c => c.EventCatagoryId == eventcategoryid.Value);
            }
         if(populareventid.HasValue)
            {
                query = query.Where(c => c.PopularEventId == populareventid.Value);
            }
        

            var itemcount = query.LongCountAsync();

            var item = await query.OrderBy(i => i.Name)
                .Skip(pagenumber * pagesize).Take(pagesize).ToListAsync();
            item = Changepictureurl(item);

            var items = new PaginatedViewModel
            {
                Pagenumber = pagenumber,
                PageSize = item.Count,
                Data = item,
                Count = itemcount.Result
            };
            return Ok(items);

        }

        private List<EventCatalog> Changepictureurl(List<EventCatalog> item)
        {
            item.ForEach(items => items.PictureUrl = items.PictureUrl.Replace("http://replace", _config["ExternalBaseUrl"]));
            return item;
        }
    }
}
