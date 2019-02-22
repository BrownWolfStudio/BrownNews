namespace BrownNews.Models.ViewModels
{
    public class HomeViewModel
    {
        public News Headlines { get; set; }
        public string ActionName { get; set; }
        public bool RenderOptionals { get; set; }
        public string Query { get; set; }
        public string Category { get; set; }
        public string Country { get; set; }
        public int Page { get; set; }
        public int PageSize { get; set; }
    }
}
