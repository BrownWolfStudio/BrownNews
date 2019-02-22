using BrownNews.Utilities;
using Microsoft.AspNetCore.Mvc;
using SimpleMvcSitemap;
using System.Collections.Generic;

namespace BrownNews.Controllers
{
    public class SitemapController : Controller
    {
        public ActionResult Index()
        {
            List<SitemapNode> nodes = new List<SitemapNode>
            {
                new SitemapNode(Url.Action("Index","Home")),
                new SitemapNode(Url.Action("Search","Home")),
                new SitemapNode(Url.Action("Privacy","Home")),
                new SitemapNode("https://brownwolfstudio.com/")
            };

            foreach (var category in ApiUtils.TopHeadlinesCategories)
            {
                nodes.Add(new SitemapNode(Url.Content($"/category/{category}")));
            }

            return new SitemapProvider().CreateSitemap(new SitemapModel(nodes));
        }
    }
}
