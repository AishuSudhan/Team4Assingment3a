using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication.OpenIdConnect;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using System.Security.Claims;

namespace WebMVCnew.controller
{
    public class AccountController : Controller
    {
        public async Task<IActionResult> SignIn(string returnurl)
        {
            var user = User as ClaimsPrincipal;

            var token = await HttpContext.GetTokenAsync("access_token");
            var idtoken = await HttpContext.GetTokenAsync("id_token");

            foreach(var claim in user.Claims)
            {
                Debug.WriteLine($"Claim Type: {claim.Type}-Claim Value: {claim.Value}");
            }
            if(token!=null)
            {
                ViewData["access_token"] = token;
            }
            if(idtoken!=null)
            {
                ViewData["id_token"] = idtoken;
            }
            return RedirectToAction(nameof(EventCatalogController.About), "EventCatalog");
        }

        public async Task<IActionResult> SignOut()
        {
            await HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
            await HttpContext.SignOutAsync(OpenIdConnectDefaults.AuthenticationScheme);

            var homeUrl = Url.Action(nameof(EventCatalogController.Index), "EventCatalog");
            return new SignOutResult(OpenIdConnectDefaults.AuthenticationScheme, 
                new AuthenticationProperties { RedirectUri = homeUrl });
        }
    }
}
