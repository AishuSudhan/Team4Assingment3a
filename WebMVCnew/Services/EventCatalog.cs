using Microsoft.AspNetCore.Mvc.Rendering;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using WebMVCnew.webInfrastructure;
using WebMVCnew.webModels;

namespace WebMVCnew.Services
{
    public class EventCatalog : IEventCatalog
    {

        private readonly IHttpClient _httpclient;
        private readonly string _baseurl;
        public EventCatalog(IConfiguration config,IHttpClient httpClient)
        {
            _httpclient = httpClient;
            _baseurl = $"{config["EventCatalogUrl"]}/api/eventcatalog";
        }
        public async Task<Paginatedclass> GetCatalogAsync(int pagenumber, int pagesize,int? popularevents,int? categories)
        {
            var customurl = APIUrlPaths.Paginatedclass.Getcatalog(_baseurl, pagenumber, pagesize, popularevents, categories);
            var datastring = await _httpclient.GetAsync(customurl);
           return JsonConvert.DeserializeObject<Paginatedclass>(datastring);
        }

        public async Task<IEnumerable<SelectListItem>> GetCategoriesAsync()
        {
            var customurl = APIUrlPaths.Paginatedclass.Geteventscategories(_baseurl);
            var datastring = await _httpclient.GetAsync(customurl);
            var events = new List<SelectListItem>()
            {
                new SelectListItem
                {
                    Value=null,
                    Text="All",
                    Selected=true
                }
            };
            var categories = JArray.Parse(datastring);
            foreach(var evt in categories)
            {
                events.Add(new SelectListItem
                {
                    Value = evt.Value<string>("id"),
                    Text=evt.Value<string>("category")
                    
                });
               
             }
            return events;
        }

        public async Task<IEnumerable<SelectListItem>> PopulareventsAsync()
        {
            var popularurl = APIUrlPaths.Paginatedclass.Getpopularevents(_baseurl);
            var popdatastring = await _httpclient.GetAsync(popularurl);
            var popevents = new List<SelectListItem>()
            {
                new SelectListItem
                {
                    Value=null,
                    Text="All",
                    Selected=true
                }
            };
            var popular = JArray.Parse(popdatastring);

            foreach (var evnt in popular)
            {
                popevents.Add(new SelectListItem
                {
                    Value = evnt.Value<string>("id"),
                    Text = evnt.Value<string>("eventName")

                });

            }

            return popevents;
        }
    }
}
