using Microsoft.AspNetCore.Authentication;
using Newtonsoft.Json;
using WebMVCnew.webInfrastructure;
using WebMVCnew.webModels;
using WebMVCnew.webModels.CartModels;
using WebMVCnew.webModels.EventOrderModels;
//using static WebMVCnew.webInfrastructure.APIUrlPaths;

namespace WebMVCnew.Services
{
    public class CartService : ICartService
    {
        private readonly string _baseUrl;
        private readonly IConfiguration _config;
        private readonly IHttpClient _apiClient;
        private readonly IHttpContextAccessor _httpContextAccesor;
        public CartService(IConfiguration config, IHttpClient httpclient, IHttpContextAccessor httpContextAccessor)
        {
            _config = config;
            _apiClient = httpclient;
            _httpContextAccesor = httpContextAccessor;
            _baseUrl = $"{config["CartUrl"]}/api/cart";
        }
        private async Task<string> GetUserTokenAsync()
        {
            var context = _httpContextAccesor.HttpContext;
            return await context.GetTokenAsync("access_token");
        }
        public async Task AddItemToCart(ApplicationUser user, CartItem product)
        {
            
            var cart = await GetCart(user);
            var basketItem = cart.Items.Where(p => p.ProductId == product.ProductId).FirstOrDefault();
            if (basketItem == null)
            {
                cart.Items.Add(product);
            }
            else
            {
                basketItem.Quantity++;
            }
            await UpdateCart(cart);
        }

        public async Task ClearCart(ApplicationUser user)
        {
            var token = await GetUserTokenAsync();
            var cleanBasketUri = APIUrlPaths.Basket.CleanBasket(_baseUrl, user.Email);
            await _apiClient.DeleteAsync(cleanBasketUri, token);
        }

        public async Task<Cart> GetCart(ApplicationUser user)
        {
            var token = await GetUserTokenAsync();
            var getBasketUri = APIUrlPaths.Basket.GetBasket(_baseUrl, user.Email);
            var dataString = await _apiClient.GetAsync(getBasketUri, token);
            var response = JsonConvert.DeserializeObject<Cart>(dataString) ??
                new Cart
                {
                    BuyerId = user.Email
                };
            return response;
        }

        public async Task<Cart> SetQuantities(ApplicationUser user, Dictionary<string, int> quantities)
        {
            
            var basket = await GetCart(user);
            basket.Items.ForEach(x =>
            {
                if (quantities.TryGetValue(x.Id, out var quantity))
                {
                    x.Quantity = quantity;
                }
            });
            return basket;
        }

        public async Task<Cart> UpdateCart(Cart cart)
        {
            var token = await GetUserTokenAsync();
            var updateBasketUri = APIUrlPaths.Basket.UpdateBasket(_baseUrl);
            var response = await _apiClient.PostAsync(updateBasketUri, cart, token);

            response.EnsureSuccessStatusCode();

            return cart;
        }
        public EventOrder MapCartToOrder(Cart cart)
        {
            var order = new EventOrder();
            order.OrderTotal = 0;

            cart.Items.ForEach(x =>
            {
                order.OrderItems.Add(new EventOrderItem()
                {
                    ProductId = int.Parse(x.ProductId),

                    PictureUrl = x.PictureUrl,
                    ProductName = x.ProductName,
                    Units = x.Quantity,
                    UnitPrice = x.UnitPrice
                });
                order.OrderTotal += (x.Quantity * x.UnitPrice);
            });

            return order;
        }

    }
}
