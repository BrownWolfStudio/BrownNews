using System.Net;
using Microsoft.AspNetCore.Hosting;

namespace BrownNews.Utilities
{
    public interface IGetCountryFromIP
    {
        IHostingEnvironment environment { get; set; }
        string GetCountryByIP(IPAddress ipAddress);
    }
}