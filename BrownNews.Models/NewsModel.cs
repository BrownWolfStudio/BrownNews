using System;
using Newtonsoft.Json;

namespace BrownNews.Models
{
    public partial class News
    {
        [JsonProperty("status", NullValueHandling = NullValueHandling.Ignore)]
        public string Status { get; set; }

        [JsonProperty("totalResults", NullValueHandling = NullValueHandling.Ignore)]
        public long? TotalResults { get; set; }

        [JsonProperty("articles", NullValueHandling = NullValueHandling.Ignore)]
        public Article[] Articles { get; set; }
    }

    public partial class Article
    {
        [JsonProperty("source", NullValueHandling = NullValueHandling.Ignore)]
        public Source Source { get; set; }

        [JsonProperty("author")]
        public string Author { get; set; }

        [JsonProperty("title", NullValueHandling = NullValueHandling.Ignore)]
        public string Title { get; set; }

        [JsonProperty("description", NullValueHandling = NullValueHandling.Ignore)]
        public string Description { get; set; }

        [JsonProperty("url", NullValueHandling = NullValueHandling.Ignore)]
        public Uri Url { get; set; }

        [JsonProperty("urlToImage", NullValueHandling = NullValueHandling.Ignore)]
        public Uri UrlToImage { get; set; }

        [JsonProperty("publishedAt", NullValueHandling = NullValueHandling.Ignore)]
        public DateTimeOffset? PublishedAt { get; set; }

        [JsonProperty("content", NullValueHandling = NullValueHandling.Ignore)]
        public string Content { get; set; }
    }

    public partial class Source
    {
        [JsonProperty("id")]
        public string Id { get; set; }

        [JsonProperty("name", NullValueHandling = NullValueHandling.Ignore)]
        public string Name { get; set; }
    }
}
