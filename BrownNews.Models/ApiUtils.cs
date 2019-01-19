using System.Collections.Generic;

namespace BrownNews.Models
{
    public static class ApiUtils
    {
        public static List<string> Countries = new List<string>
        {
            "ae", "ar", "at", "au", "be", "bg", "br", "ca", "ch", "cn", "co", "cu", "cz", "de", "eg", "fr", "gb", "gr", "hk", "hu", "id", "ie", "il", "in", "it", "jp", "kr", "lt", "lv", "ma", "mx", "my", "ng", "nl", "no", "nz", "ph", "pl", "pt", "ro", "rs", "ru", "sa", "se", "sg", "si", "sk", "th", "tr", "tw", "ua", "us", "ve", "za"
        };

        public static List<string> TopHeadlinesCategories = new List<string>
        {
            "general", "business", "entertainment", "health", "science", "sports", "technology"
        };

        public static bool IsSupported(string country)
        {
            return Countries.Contains(country);
        }
    }
}
