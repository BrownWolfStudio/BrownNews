using MaxMind.GeoIP2;
using Microsoft.AspNetCore.Hosting;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace BrownNews.Utilities
{
    public class GetCountryFromIP : IGetCountryFromIP
    {
        public IHostingEnvironment environment { get; set; }

        public GetCountryFromIP(IHostingEnvironment env)
        {
            environment = env;
        }

        public string GetCountryByIP(IPAddress ipAddress)
        {
            using (var reader = new DatabaseReader(Path.Combine(environment.ContentRootPath, "GeoLite2-Country.mmdb")))
            {
                var response = reader.Country(ipAddress);
                return response.Country.IsoCode;
            }
        }
    }
}
