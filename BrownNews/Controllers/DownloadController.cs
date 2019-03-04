using BrownNews.Services;
using BrownNews.Utilities;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;

namespace BrownNews.Controllers
{
    public class DownloadController : Controller
    {
        private readonly IDownloadNewsPaperService _downloadNewsPaperService;

        public DownloadController(IDownloadNewsPaperService downloadNewsPaperService)
        {
            _downloadNewsPaperService = downloadNewsPaperService;
        }

        public IActionResult Index()
        {
            return View();
        }

        public async Task<IActionResult> GujaratSamacharRajkot()
        {
            var files = await _downloadNewsPaperService.GetGsRkFilesAsync();
            return File(files.ZipIt(), "application/zip", $"{nameof(GujaratSamacharRajkot)}-{DateTime.Now.ToString("ddMMyyyy")}.zip");
        }

        public async Task<IActionResult> DivyaBhaskarRajkot()
        {
            var files = await _downloadNewsPaperService.GetDbRkFilesAsync();
            return File(files.ZipIt(), "application/zip", $"{nameof(DivyaBhaskarRajkot)}-{DateTime.Now.ToString("ddMMyyyy")}.zip");
        }
    }
}
