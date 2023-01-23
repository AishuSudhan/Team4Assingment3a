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
        private readonly IEventCatalog _catalogservice;
        private readonly IIdentityService<ApplicationUser> _identityService;

        public CartController(IIdentityService<ApplicationUser> identityService,
            ICartService cartService, IEventCatalog catalogService)
        {
            _identityService = identityService;
            _cartService = cartService;
            _catalogservice = catalogService;
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
                return RedirectToAction("Create", "Order");
            }


            try
            {
                var user = _identityService.Get(HttpContext.User);
                var basket = await _cartService.SetQuantities(user, quantities);
                var vm = await _cartService.UpdateCart(basket);

            }
            catch (BrokenCircuitException)
            {
                // Catch error when CartApi is in open circuit  mode                 
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
                        EventName = productDetails.Name,
                        PictureUrl = productDetails.PictureUrl,
                        UnitPrice = productDetails.Price,
                        EventId = productDetails.Id.ToString(),

                    };
                    await _cartService.AddItemToCart(user, product);
                }
            }
            catch (BrokenCircuitException)
            {
                // Catch error when CartApi is in circuit-opened mode                 
                HandleBrokenCircuitException();
            }

            return RedirectToAction("Index", "Catalog");

        }

        private void HandleBrokenCircuitException()
        {
            throw new NotImplementedException();
        }
    }
    }

