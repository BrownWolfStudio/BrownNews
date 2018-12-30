//namespace BrownNews.Models
//{
//    using Newtonsoft.Json;
//    using Newtonsoft.Json.Converters;
//    using System;
//    using System.Globalization;

//    public partial class Headlines
//    {
//        [JsonProperty("status", NullValueHandling = NullValueHandling.Ignore)]
//        public string Status { get; set; }

//        [JsonProperty("totalResults", NullValueHandling = NullValueHandling.Ignore)]
//        public long? TotalResults { get; set; }

//        [JsonProperty("articles", NullValueHandling = NullValueHandling.Ignore)]
//        public Article[] Articles { get; set; }
//    }

//    public partial class Article
//    {
//        [JsonProperty("source", NullValueHandling = NullValueHandling.Ignore)]
//        public Source Source { get; set; }

//        [JsonProperty("author", NullValueHandling = NullValueHandling.Ignore)]
//        public Author? Author { get; set; }

//        [JsonProperty("title", NullValueHandling = NullValueHandling.Ignore)]
//        public string Title { get; set; }

//        [JsonProperty("description", NullValueHandling = NullValueHandling.Ignore)]
//        public string Description { get; set; }

//        [JsonProperty("url", NullValueHandling = NullValueHandling.Ignore)]
//        public Uri Url { get; set; }

//        [JsonProperty("urlToImage", NullValueHandling = NullValueHandling.Ignore)]
//        public Uri UrlToImage { get; set; }

//        [JsonProperty("publishedAt", NullValueHandling = NullValueHandling.Ignore)]
//        public DateTimeOffset? PublishedAt { get; set; }

//        [JsonProperty("content")]
//        public string Content { get; set; }
//    }

//    public partial class Source
//    {
//        [JsonProperty("id", NullValueHandling = NullValueHandling.Ignore)]
//        public Id? Id { get; set; }

//        [JsonProperty("name", NullValueHandling = NullValueHandling.Ignore)]
//        public Author? Name { get; set; }
//    }

//    public enum Author { BbcNews };

//    public enum Id { BbcNews };

//    public partial class Headlines
//    {
//        public static Headlines FromJson(string json) => JsonConvert.DeserializeObject<Headlines>(json, Converter.Settings);
//    }

//    public static class Serialize
//    {
//        public static string ToJson(this Headlines self) => JsonConvert.SerializeObject(self, Converter.Settings);
//    }

//    internal static class Converter
//    {
//        public static readonly JsonSerializerSettings Settings = new JsonSerializerSettings
//        {
//            MetadataPropertyHandling = MetadataPropertyHandling.Ignore,
//            DateParseHandling = DateParseHandling.None,
//            Converters =
//            {
//                AuthorConverter.Singleton,
//                IdConverter.Singleton,
//                new IsoDateTimeConverter { DateTimeStyles = DateTimeStyles.AssumeUniversal }
//            },
//        };
//    }

//    internal class AuthorConverter : JsonConverter
//    {
//        public override bool CanConvert(Type t) => t == typeof(Author) || t == typeof(Author?);

//        public override object ReadJson(JsonReader reader, Type t, object existingValue, JsonSerializer serializer)
//        {
//            if (reader.TokenType == JsonToken.Null) return null;
//            var value = serializer.Deserialize<string>(reader);
//            if (value == "BBC News")
//            {
//                return Author.BbcNews;
//            }
//            throw new Exception("Cannot unmarshal type Author");
//        }

//        public override void WriteJson(JsonWriter writer, object untypedValue, JsonSerializer serializer)
//        {
//            if (untypedValue == null)
//            {
//                serializer.Serialize(writer, null);
//                return;
//            }
//            var value = (Author)untypedValue;
//            if (value == Author.BbcNews)
//            {
//                serializer.Serialize(writer, "BBC News");
//                return;
//            }
//            throw new Exception("Cannot marshal type Author");
//        }

//        public static readonly AuthorConverter Singleton = new AuthorConverter();
//    }

//    internal class IdConverter : JsonConverter
//    {
//        public override bool CanConvert(Type t) => t == typeof(Id) || t == typeof(Id?);

//        public override object ReadJson(JsonReader reader, Type t, object existingValue, JsonSerializer serializer)
//        {
//            if (reader.TokenType == JsonToken.Null) return null;
//            var value = serializer.Deserialize<string>(reader);
//            if (value == "bbc-news")
//            {
//                return Id.BbcNews;
//            }
//            throw new Exception("Cannot unmarshal type Id");
//        }

//        public override void WriteJson(JsonWriter writer, object untypedValue, JsonSerializer serializer)
//        {
//            if (untypedValue == null)
//            {
//                serializer.Serialize(writer, null);
//                return;
//            }
//            var value = (Id)untypedValue;
//            if (value == Id.BbcNews)
//            {
//                serializer.Serialize(writer, "bbc-news");
//                return;
//            }
//            throw new Exception("Cannot marshal type Id");
//        }

//        public static readonly IdConverter Singleton = new IdConverter();
//    }
//}






namespace BrownNews.Models
{
    using System;
    using System.Collections.Generic;

    using System.Globalization;
    using Newtonsoft.Json;
    using Newtonsoft.Json.Converters;

    public partial class Headlines
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
