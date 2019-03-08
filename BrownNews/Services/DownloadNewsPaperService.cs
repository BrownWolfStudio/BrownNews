using BrownNews.Models;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;

namespace BrownNews.Services
{
    public class DownloadNewsPaperService : IDownloadNewsPaperService
    {
        public HttpClient Client { get; set; }
        private int Page { get; set; }

        private string GsRkUrlFormat { get; set; } = "http://enewspapr.com/News/GUJARAT/RAJ/{0:yyyy}/{0:MM}/{0:dd}/{0:yyyyMMdd}_{4}.PDF";
        public string GsRkCurrentUrl
        {
            get
            {
                var date = DateTime.Now;
                return string.Format(GsRkUrlFormat, date, Page);
            }
        }

        private string DbRkUrlFormat { get; set; } = "http://digitalimages.bhaskar.com/gujarat/epaperimages/{0:ddMMyyyy}/{1:d}rajkot%20city-pg{2}-0ll.jpg";
        public string DbRkCurrentUrl
        {
            get
            {
                var date = DateTime.Now;
                return string.Format(DbRkUrlFormat, date, int.Parse(date.ToString("d")) - 1, Page);
            }
        }

        public DownloadNewsPaperService(HttpClient client)
        {
            Client = client;
        }

        public async Task<List<SourceFile>> GetGsRkFilesAsync()
        {
            Page = 1;
            List<SourceFile> sourceFiles = new List<SourceFile>();
            var url = GsRkCurrentUrl;
            var response = await Client.GetAsync(url);
            while (response.IsSuccessStatusCode)
            {
                var source = new SourceFile { Name = $"GujaratSamachar-{Page}", Extension = "pdf", FileBytes = await response.Content.ReadAsByteArrayAsync() };
                sourceFiles.Add(source);
                Page++;
                url = GsRkCurrentUrl;
                response = await Client.GetAsync(url);
            }

            return sourceFiles;
        }

        public async Task<List<SourceFile>> GetDbRkFilesAsync()
        {
            Page = 1;
            List<SourceFile> sourceFiles = new List<SourceFile>();
            var url = DbRkCurrentUrl;
            var response = await Client.GetAsync(url);
            while (response.IsSuccessStatusCode)
            {
                var source = new SourceFile { Name = $"DivyaBhaskar-{Page}", Extension = "jpg", FileBytes = await response.Content.ReadAsByteArrayAsync() };
                sourceFiles.Add(source);
                Page++;
                url = DbRkCurrentUrl;
                response = await Client.GetAsync(url);
            }

            return sourceFiles;
        }
    }
}
