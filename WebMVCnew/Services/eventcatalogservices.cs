using Microsoft.AspNetCore.Mvc.Rendering;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System.Runtime.CompilerServices;
using System.Text.Json.Serialization;
using WebMVCnew.webInfrastructure;
using WebMVCnew.webModels;

namespace WebMVCnew.Services
{
    public class eventcatalogservices : IEventCatalog
    {
        private readonly IHttpClient _httpclient;
        private readonly string _baseUrl;
        public eventcatalogservices(IConfiguration config,IHttpClient httpClient)
        {
            _httpclient = httpClient;
            _baseUrl = $"{config["EventCatalogUrl"]}/api/eventcatalog";

        }
        public async Task<eventcatalogClass> GetCatalogAsync(int pagenumber, int pagesize)
        {
           var CustomUrl= APIUrlPaths.catalogevents.getcatalog(_baseUrl, pagenumber, pagesize);
            var datastring = await _httpclient.GetAsync(CustomUrl);
            return JsonConvert.DeserializeObject<eventcatalogClass>(datastring);
        }

        public async Task<IEnumerable<SelectListItem>> GetCategoriesAsync()
        {
            var customurl = APIUrlPaths.catalogevents.geteventscategories(_baseUrl);
            var datastring = await _httpclient.GetAsync(customurl);
            var item = new List<SelectListItem>()
            {
                new SelectListItem
                {
                Value = null,
                Text = "All",
                Selected = true
                }
            };
            var categories = JArray.Parse(datastring);
            foreach(var items in categories)
            {
                item.Add(new SelectListItem
                {
                    Value = items.Value<string>("Id"),
                    Text = items.Value<string>("Category")
                });
            }
            return item;
        }

        public async Task<IEnumerable<SelectListItem>> PopulareventsAsync()
        {
            var customurl = APIUrlPaths.catalogevents.getpopularevents(_baseUrl);
            var datastring = await _httpclient.GetAsync(customurl);
            var item = new List<SelectListItem>()
            {
                new SelectListItem
                {
                    Value=null,
                    Text="All",
                    Selected=true
                }
            };
            var popularevents = JArray.Parse(datastring);
            foreach(var items in popularevents)
            {
                item.Add(new SelectListItem
                {
                    Value = items.Value<string>("Id"),
                    Text = items.Value<string>("EventName")
                });
            }
            return item;
        }
    }
}
