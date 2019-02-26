using System;
using System.ComponentModel.DataAnnotations;
using Newtonsoft.Json;

namespace BrownNews.Models
{
    public partial class Article
    {
        [Key]
        [Required]
        public string Id { get; set; }

        [JsonProperty("source")]
        public Source Source { get; set; }

        [JsonProperty("author")]
        public string Author { get; set; }

        [JsonProperty("title")]
        public string Title { get; set; }

        [JsonProperty("description")]
        public string Description { get; set; }
        
        [JsonProperty("url")]
        public Uri Url { get; set; }

        [JsonProperty("urlToImage")]
        public Uri UrlToImage { get; set; }

        [JsonProperty("publishedAt")]
        public DateTimeOffset? PublishedAt { get; set; }

        [JsonProperty("content")]
        public string Content { get; set; }
    }
}
