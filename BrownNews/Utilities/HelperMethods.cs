using System;

namespace BrownNews.Utilities
{
    public static class HelperMethods
    {
        public static string HttpToHttps(this Uri uri)
        {
            string imgUri = null;
            if (uri != null)
            {
                imgUri = new UriBuilder(uri)
                {
                    Scheme = Uri.UriSchemeHttps,
                    Port = -1
                }.Uri.ToString();
            }
            return imgUri;
        }
    }
}
