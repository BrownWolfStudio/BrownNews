using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace BrownNews.Controllers
{
    [Authorize]
    public class UserController : Controller
    {
        public IActionResult EditProfile()
        {
            return View();
        }

        public IActionResult Articles()
        {
            return View();
        }
    }
}
