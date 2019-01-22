using BrownNews.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using System.Threading.Tasks;
using System;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using BrownNews.Utilities;

namespace BrownNews.Controllers
{
    public class HomeController : Controller
    {
        public IConfiguration Configuration { get; }
        public string API_KEY { get; }

        public HomeController(IConfiguration configuration)
        {
            Configuration = configuration;
            API_KEY = Configuration["NewsApiKey"];
        }

        [Route("", Name = "HomePage")]
        [Route("category/{category}")]
        public async Task<IActionResult> Index(string category = "general")
        {
            var country = HttpContext.Request.Headers["CF-IPCountry"].ToString().ToLower();
            country = ApiUtils.IsSupported(country) ? country : "us";

            var client = HelperMethods.SetupUrlAndClient(API_KEY, $"country={country}", $"category={category}");

            Headlines model = new Headlines();
            try
            {
                model = await client.GetHeadlinesAsync();
            }
            catch (Exception)
            {
                return View("Error");
            }
            return View(model);
        }

        [Route("/{country}")]
        public async Task<IActionResult> IndexByCountry(string country = "us")
        {
            country = ApiUtils.IsSupported(country) ? country : "us";

            var client = HelperMethods.SetupUrlAndClient(API_KEY, $"country={country}");

            Headlines model = new Headlines();
            try
            {
                model = await client.GetHeadlinesAsync();
            }
            catch (Exception)
            {
                return View("Error");
            }
            return View("Index", model);
        }

        [Route("/Privacy")]
        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
