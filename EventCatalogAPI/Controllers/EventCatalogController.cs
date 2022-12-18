using EventCatalogAPI.Data;
using EventCatalogAPI.domain;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace EventCatalogAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EventCatalogController : ControllerBase
    {
        public readonly EventCatalogContext _eventCatalogContext;
        public EventCatalogController(EventCatalogContext eventCatalogContext)
        {
            _eventCatalogContext = eventCatalogContext;
        }
        [HttpGet("[action]")]
        public async Task<IActionResult> Getcategories()
        {
           var category=await _eventCatalogContext.eventCatagories.ToListAsync();
            return Ok(category);
        }
        [HttpGet("[action]")]
        public async Task<IActionResult> GetpopularEvents()
        {
          var popularevents=await  _eventCatalogContext.popularEvents.ToListAsync();
            return Ok(popularevents);
        }
    }
}
