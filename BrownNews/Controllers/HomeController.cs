using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using System.Threading.Tasks;
using System;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using BrownNews.Utilities;
using BrownNews.Models.ViewModels;

namespace BrownNews.Controllers
{
    public class HomeController : Controller
    {
        public IConfiguration Configuration { get; }
        public string API_KEY { get; }
        public int pageSize { get; set; } = 12;

        public HomeController(IConfiguration configuration)
        {
            Configuration = configuration;
            API_KEY = Configuration["NewsApiKey"];
        }

        [Route("", Name = "HomePage")]
        [Route("category/{category}")]
        public async Task<IActionResult> Index(string category = "general", int page = 1)
        {
            var country = HttpContext.Request.Headers["CF-IPCountry"].ToString().ToLower();
            country = ApiUtils.Countries.Contains(country) ? country : "us";

            var client = HelperMethods.SetupUrlAndClient(API_KEY, HelperMethods.NewsType.TopHeadlines, $"country={country}", $"category={category}", $"pageSize={pageSize}", $"page={page}");

            var model = new HomeViewModel
            {
                ActionName = nameof(Index),
                RenderOptionals = true,
                Category = category,
                Country = country,
                Page = page,
                PageSize = pageSize
            };
            try
            {
                model.Headlines = await client.GetNewsAsync();
            }
            catch (Exception)
            {
                return View("Error", new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
            }
            return View(model);
        }
        
        public async Task<IActionResult> Search(string q = "technology", int page = 1)
        {
            var client = HelperMethods.SetupUrlAndClient(API_KEY, HelperMethods.NewsType.Everything, $"q={q}", $"pageSize={pageSize}", $"page={page}");

            var model = new HomeViewModel
            {
                ActionName = nameof(Index),
                RenderOptionals = true,
                Query = q,
                Page = page,
                PageSize = pageSize
            };
            try
            {
                model.Headlines = await client.GetNewsAsync();
            }
            catch (Exception)
            {
                return View("Error", new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
            }
            return View(model);
        }

        [Route("/{country}")]
        public async Task<IActionResult> IndexByCountry(string country = "us", string category = "general", int page = 1)
        {
            country = ApiUtils.Countries.Contains(country) ? country : "us";

            var client = HelperMethods.SetupUrlAndClient(API_KEY, HelperMethods.NewsType.TopHeadlines, $"country={country}");

            var model = new HomeViewModel
            {
                ActionName = nameof(IndexByCountry),
                RenderOptionals = false,
                Category = category,
                Country = country,
                Page = page,
                PageSize = pageSize
            };
            try
            {
                model.Headlines = await client.GetNewsAsync();
            }
            catch (Exception)
            {
                return View("Error", new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
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
