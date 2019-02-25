using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace BrownNews.Controllers
{
    [Route("Auth")]
    public class AuthController : Controller
    {
        [Route("SignIn")]
        public IActionResult SignIn(string returnUrl)
        {
            return Challenge(new AuthenticationProperties { RedirectUri = returnUrl ?? "/" });
        }

        [Route("SignOut")]
        public async Task<IActionResult> SignOut()
        {
            await HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
            return RedirectToAction("Index", "Home");
        }
    }
}
