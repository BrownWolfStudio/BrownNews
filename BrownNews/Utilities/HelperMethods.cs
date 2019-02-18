using System;

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


        public static int CalculatePagesForPagination(int totalResults, int pageSize)
        {
            if (totalResults < pageSize)
            {
                return 1;
            }

            // Using dev account on NewsApi.org so can only fetch 100 results
            // Setting it to 96 to round off as we use 12 results per page
            if (totalResults > 96)
            {
                totalResults = 96;
            }

            int pages = totalResults / pageSize;
            if (totalResults % pageSize >= 1) pages++;
            return pages;
        }

        public static ApiClient.ApiClient SetupUrlAndClient(string API_KEY, NewsType newsType = NewsType.TopHeadlines, params string[] urlParams)
        {
            var uriStr = "";
            switch (newsType)
            {
                case NewsType.TopHeadlines:
                    uriStr = "https://newsapi.org/v2/top-headlines/?apiKey=" + API_KEY;
                    break;
                case NewsType.Everything:
                    uriStr = "https://newsapi.org/v2/everything/?apiKey=" + API_KEY;
                    break;
                default:
                    uriStr = "https://newsapi.org/v2/top-headlines/?apiKey=" + API_KEY;
                    break;
            }
            foreach (var item in urlParams)
            {
                uriStr += $"&{item}";
            }
            return new ApiClient.ApiClient(new Uri(uriStr));
        }

        public enum NewsType
        {
            TopHeadlines,
            Everything
        }
    }
}
