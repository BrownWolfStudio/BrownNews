using Newtonsoft.Json;

namespace BrownNews.Models
{
    public partial class News
    {
        [JsonProperty("status")]
        public string Status { get; set; }

        [JsonProperty("totalResults")]
        public long? TotalResults { get; set; }

        [JsonProperty("articles")]
        public Article[] Articles { get; set; }
    }
}
