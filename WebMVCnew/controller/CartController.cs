using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Polly.CircuitBreaker;
using WebMVCnew.Services;
using WebMVCnew.webModels;
using WebMVCnew.webModels.CartModels;

namespace WebMVCnew.controller
{
    [Authorize]
    public class CartController : Controller
    {
        private readonly ICartService _cartService;
        private readonly IEventCatalog _catalogService;
        private readonly IIdentityService<ApplicationUser> _identityService;

        public CartController(IIdentityService<ApplicationUser> identityService,
            ICartService cartService, IEventCatalog catalogService)
        {
            _identityService = identityService;
            _cartService = cartService;
            _catalogService = catalogService;
        }
        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Index(Dictionary<string, int> quantities,
           string action)
        {
            if (action == "[ Checkout ]")
            {
                return RedirectToAction("Create", "EventOrders");
            }


            try
            {
                var user = _identityService.Get(HttpContext.User);
                var basket = await _cartService.SetQuantities(user, quantities);
                var vm = await _cartService.UpdateCart(basket);

            }
            catch (BrokenCircuitException)
            {
                               
                HandleBrokenCircuitException();
            }

            return View();

        }


        [HttpPost]
        public async Task<IActionResult> AddToCart(EventcatalogClass productDetails)
        {
            try
            {
                if (productDetails.Id > 0)
                {
                    var user = _identityService.Get(HttpContext.User);
                    var product = new CartItem()
                    {
                        Id = Guid.NewGuid().ToString(),
                        Quantity = 1,
                        ProductName = productDetails.Name,
                        PictureUrl = productDetails.PictureUrl,
                        UnitPrice = productDetails.Price,
                        ProductId = productDetails.Id.ToString()
                    };
                    await _cartService.AddItemToCart(user, product);
                }
            }
            catch (BrokenCircuitException)
            {
                               
                HandleBrokenCircuitException();
            }

            return RedirectToAction("Index", "EventCatalog");

        }

        private void HandleBrokenCircuitException()
        {
            TempData["BasketInoperativeMsg"] = "cart Service is inoperative, please try later on. (Business Msg Due to Circuit-Breaker)";
        }
    }
}
