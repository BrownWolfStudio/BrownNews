using BrownNews.Models;
using System;
using System.Threading.Tasks;

namespace BrownNews.Utilities
{
    public static class HelperMethods
    {
        public static Uri HttpToHttps(this Uri uri)
        {
            Uri imgUri = null;
            if (uri != null)
            {
                imgUri = new UriBuilder(uri)
                {
                    Scheme = Uri.UriSchemeHttps,
                    Port = -1
                }.Uri;
            }
            return imgUri;
        }

        public static ApiClient.ApiClient SetupUrlAndClient(string API_KEY, params string[] urlParams)
        {
            var uriStr = "https://newsapi.org/v2/top-headlines/?apiKey=" + API_KEY;
            foreach (var item in urlParams)
            {
                uriStr += $"&{item}";
            }
            return new ApiClient.ApiClient(new Uri(uriStr));
        }
    }
}
