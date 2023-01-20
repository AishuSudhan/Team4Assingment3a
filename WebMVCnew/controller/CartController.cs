using Microsoft.AspNetCore.Mvc;

namespace WebMVCnew.controller
{
    public class CartController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
