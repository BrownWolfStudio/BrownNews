using BrownNews.Models;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;

namespace BrownNews.Services
{
    public interface IDownloadNewsPaperService
    {
        HttpClient Client { get; set; }
        Task<List<SourceFile>> GetGsRkFilesAsync();
        Task<List<SourceFile>> GetDbRkFilesAsync();
    }
}
