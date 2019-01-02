using BrownNews.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using System.Threading.Tasks;
using System;
using Microsoft.AspNetCore.Http;

namespace BrownNews.Controllers
{
    public class HomeController : Controller
    {        
        [Route("")]
        public async Task<IActionResult> Index()
        {
            var country = "in";

            var uriStr = "https://newsapi.org/v2/top-headlines/?country=" + country + "&apiKey=" + Environment.GetEnvironmentVariable("NewsApiKey");
            var client = new ApiClient.ApiClient(new Uri(uriStr));

            Headlines model = new Headlines();
            try
            {
                model = await client.GetHeadlines();
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
            var uriStr = "https://newsapi.org/v2/top-headlines/?country=" + country + "&apiKey=" + Environment.GetEnvironmentVariable("NewsApiKey");
            var client = new ApiClient.ApiClient(new Uri(uriStr));
            Headlines model = new Headlines();
            try
            {
                model = await client.GetHeadlines();
            }
            catch (Exception)
            {
                return View("Error");
            }
            return View("Index", model);
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
