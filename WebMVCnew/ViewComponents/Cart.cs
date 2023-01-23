using Microsoft.AspNetCore.Mvc;
using Polly.CircuitBreaker;
using WebMVCnew.webModels;

using WebMVCnew.Services;
using WebMVCnew.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebMVCnew.ViewComponents
{
    public class Cart:ViewComponent
    {
        private readonly ICartService _catSvc;

        public Cart(ICartService cartSvc) => _catSvc = cartSvc;
        public async Task<IViewComponentResult> InvokeAsync(ApplicationUser user) 
        {

            
            var vm = new CartComponentViewModel();
            try
            {
                var cart = await _catSvc.GetCart(user);

                vm.ItemsInCart = cart.Items.Count;
                vm.TotalCost = cart.Total();
                return View(vm);
            }
            catch(BrokenCircuitException)
            {
                // Catch error when CartApi is in open circuit mode
                ViewBag.IsBasketInoperative = true;
            }
            
            return View(vm);
        }

    }
}
