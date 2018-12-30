using BrownNews.Models;
using BrownNews.Utilities;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using System.Threading.Tasks;
using System;
using Microsoft.AspNetCore.Http;
using System.Net;

namespace BrownNews.Controllers
{
    public class HomeController : Controller
    {
        private readonly IGetCountryFromIP GeoIPUtil;

        public HomeController(IGetCountryFromIP ipUtil)
        {
            GeoIPUtil = ipUtil;
        }
        
        [Route("")]
        public async Task<IActionResult> Index()
        {
            var ip = Request.HttpContext?.Connection?.RemoteIpAddress?.ToString();
            var country = "in";

            if (ip != null || ip != "127.0.0.1")
            {
                try { country = GeoIPUtil.GetCountryByIP(IPAddress.Parse(ip)); }
                catch { }
            }

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
