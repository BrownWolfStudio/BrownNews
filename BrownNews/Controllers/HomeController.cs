using BrownNews.Factory;
using BrownNews.Models;
using BrownNews.Utilities;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using System.Globalization;
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

        public async Task<IActionResult> Index()
        {
            var ip = Request.HttpContext?.Connection?.RemoteIpAddress?.ToString();
            var country = "in";
            if (ip != null || ip != "127.0.0.1")
            {
                try { country = GeoIPUtil.GetCountryByIP(IPAddress.Parse(ip)); }
                catch { }
            }
            ApplicationSettings.WebApiUrl = "https://newsapi.org/v2/top-headlines/?country=" + country + "&apiKey=" + Environment.GetEnvironmentVariable("NewsApiKey");
            Headlines model = new Headlines();
            try
            {
                model = await ApiClientFactory.Instance.GetHeadlines();
            }
            catch (Exception)
            {
                return View("Error");
            }
            return View(model);
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
