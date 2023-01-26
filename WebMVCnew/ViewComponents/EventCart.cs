using Microsoft.AspNetCore.Mvc;
using Polly.CircuitBreaker;
using WebMVCnew.Services;
using WebMVCnew.ViewModels;
using WebMVCnew.webModels;

namespace WebMVCnew.ViewComponents
{
    public class EventCart:ViewComponent
    {
        private readonly ICartService _cartSvc;

        public EventCart(ICartService cartSvc) => _cartSvc = cartSvc;
        public async Task<IViewComponentResult> InvokeAsync(ApplicationUser user)
        {


            var vm = new EventCartComponentViewModel();
            try
            {
                var cart = await _cartSvc.GetCart(user);

                vm.ItemsInCart = cart.Items.Count;
                vm.TotalCost = cart.Total();
                return View(vm);
            }
            catch (BrokenCircuitException)
            {
                // Catch error when CartApi is in open circuit mode
                ViewBag.IsBasketInoperative = true;
            }

            return View(vm);
        }

    }
}
