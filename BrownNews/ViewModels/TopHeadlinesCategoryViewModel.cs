using System.Collections.Generic;

namespace BrownNews.ViewModels
{
    public class TopHeadlinesCategoryViewModel
    {
        public List<string> TopHeadlinesCategories { get; set; }
        public string CurrentCategory { get; set; }

        public bool CompareCategories(string category)
        {
            return CurrentCategory.ToLower() == category.ToLower();
        }
    }
}
