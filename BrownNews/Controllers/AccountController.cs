using BrownNews.Data;
using BrownNews.Utilities;
using BrownNews.ViewModels;
using Humanizer;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace BrownNews.Controllers
{
    public class AccountController : Controller
    {
        private readonly UserManager<User> _userManager;
        private readonly SignInManager<User> _signInManager;
        private readonly AppDbContext _context;

        public AccountController(UserManager<User> userManager, SignInManager<User> signInManager, AppDbContext context)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _context = context;
        }

        [HttpGet]
        public IActionResult Login(string returnUrl = null)
        {
            var path = HttpContext.Request.Path;
            var model = new LoginViewModel();
            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Login(LoginViewModel model, string returnUrl = null)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            var user = await _userManager.FindByNameAsync(model.UserName);
            var correctPassword = await _userManager.CheckPasswordAsync(user, model.Password);
            if (!correctPassword)
            {
                ModelState.AddModelError("", "Invalid Username or password.");
                return View(model);
            }

            var isLockedOut = await _userManager.IsLockedOutAsync(user);
            if (isLockedOut)
            {
                var time = await _userManager.GetLockoutEndDateAsync(user);
                ModelState.AddModelError("", $"Your account is locked out due to several failed login attempts. Lockout ends: {time.Value.Humanize()}.");
                return View(model);
            }

            var result = await _signInManager.PasswordSignInAsync(model.UserName, model.Password, true, true);
            if (result.Succeeded)
            {
                if (returnUrl != null) return Redirect(returnUrl);
                return RedirectToAction("Index", "Home");
            }
            else
            {
                ModelState.AddModelError("", "Something went wrong! Try again later.");
                return View(model);
            }
        }

        [HttpGet]
        public IActionResult Register()
        {
            var model = new RegisterViewModel();
            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Register(RegisterViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            var userByUsername = await _userManager.FindByNameAsync(model.UserName);
            var userByEmail = await _userManager.FindByEmailAsync(model.Email);

            if (userByUsername != null)
            {
                ModelState.AddModelError("", "Username already exists.");
                return View(model);
            }

            if (userByEmail != null)
            {
                ModelState.AddModelError("", "Email Address already exists.");
                return View(model);
            }

            var user = new User { UserName = model.UserName, Email = model.Email, GravatarEmailHash = HelperMethods.GenerateEmailHash(model.Email) };
            var result = await _userManager.CreateAsync(user, model.Password);

            if (result.Succeeded)
            {
                await _signInManager.SignInAsync(user, false);
                return RedirectToAction("Index", "Home");
            }
            else
            {
                foreach (var error in result.Errors)
                {
                    ModelState.AddModelError("", error.Code.Humanize());
                }
                return View(model);
            }
        }

        [HttpGet]
        public async Task<IActionResult> SignOut()
        {
            await _signInManager.SignOutAsync();
            return RedirectToAction("Index", "Home");
        }

        [HttpPost]
        public async Task<IActionResult> IsUserNameTaken(string username)
        {
            var user = await _userManager.FindByNameAsync(username);
            return Json(user == null ? false : true);
        }
    }
}
