using Microsoft.AspNetCore.Authentication;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using WebMVCnew.webInfrastructure;
using WebMVCnew.webModels.EventOrderModels;

namespace WebMVCnew.Services
{
    public class EventOrderService : IEventOrderService
    {
        private IHttpClient _apiClient;
        private readonly string _remoteServiceBaseUrl;
        private readonly IConfiguration _config;
        private readonly IHttpContextAccessor _httpContextAccesor;
        private readonly ILogger _logger;
        public EventOrderService(IConfiguration config,
            IHttpContextAccessor httpContextAccesor,
            IHttpClient httpClient, ILoggerFactory logger)
        {
            _remoteServiceBaseUrl = $"{config["OrderUrl"]}/api/eventorders";
            _config = config;
            _httpContextAccesor = httpContextAccesor;
            _apiClient = httpClient;
            _logger = logger.CreateLogger<EventOrderService>();
        }
        private async Task<string> GetUserTokenAsync()
        {
            var context = _httpContextAccesor.HttpContext;
            return await context.GetTokenAsync("access_token");
        }
        public async Task<int> CreateOrder(EventOrder order)
        {
            var token = await GetUserTokenAsync();
            var addNewOrderUri = APIUrlPaths.EventOrder.AddNewOrder(_remoteServiceBaseUrl);
            _logger.LogDebug(" OrderUri " + addNewOrderUri);

            var response = await _apiClient.PostAsync(addNewOrderUri, order, token);
            if (response.StatusCode == System.Net.HttpStatusCode.InternalServerError)
            {
                throw new Exception("Error creating order, try later.");
            }

            var jsonString = response.Content.ReadAsStringAsync();
            jsonString.Wait();
            dynamic data = JObject.Parse(jsonString.Result);
            string value = data.orderId;
            return Convert.ToInt32(value);
        }

        public async Task<EventOrder> GetOrder(string orderId)
        {
            var token = await GetUserTokenAsync();
            var getOrderUri = APIUrlPaths.EventOrder.GetOrder(_remoteServiceBaseUrl, orderId);

            var dataString = await _apiClient.GetAsync(getOrderUri, token);
            var response = JsonConvert.DeserializeObject<EventOrder>(dataString);
            return response;
        }
    }
}
