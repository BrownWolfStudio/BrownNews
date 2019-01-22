using Microsoft.AspNetCore.Mvc;
using SimpleMvcSitemap;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BrownNews.Controllers
{
    public class SitemapController : Controller
    {
        public ActionResult Index()
        {
            List<SitemapNode> nodes = new List<SitemapNode>
            {
                new SitemapNode(Url.Action("Index","Home")),
                new SitemapNode(Url.Action("Privacy","Home")),
                new SitemapNode("https://brownwolfstudio.com/")
            };

            return new SitemapProvider().CreateSitemap(new SitemapModel(nodes));
        }
    }
}
