using Newtonsoft.Json;
using System.ComponentModel.DataAnnotations;

namespace BrownNews.Models
{
    public partial class Source
    {
        [Key]
        [Required]
        public string Id { get; set; }
        
        [JsonProperty("id")]
        public string SourceId { get; set; }

        [JsonProperty("name")]
        public string Name { get; set; }
    }
}
