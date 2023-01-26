using Microsoft.AspNetCore.Mvc;
using Polly.CircuitBreaker;
using System.Reflection;
using WebMVCnew.Services;
using WebMVCnew.webModels;

namespace WebMVCnew.ViewComponents
{
    public class EventCartList:ViewComponent
    {
        private readonly ICartService _cartSvc;

        public EventCartList(ICartService cartSvc) => _cartSvc = cartSvc;
        public async Task<IViewComponentResult> InvokeAsync(ApplicationUser user)
        {


            var vm = new webModels.CartModels.Cart();
            try
            {
                vm = await _cartSvc.GetCart(user);


                return View(vm);
            }
            catch (BrokenCircuitException)
            {
                // Catch error when CartApi is in open circuit mode
                ViewBag.IsBasketInoperative = true;
                TempData["BasketInoperativeMsg"] = "Basket Service is inoperative, please try later on. (Business Msg Due to Circuit-Breaker)";
            }

            return View(vm);
        }

    }
}
