using System.Text.Json.Serialization;

namespace Cars.Api.Models
{
    public class ColModel
    {
        [JsonPropertyName("id")]
        public string Id { get; set; }

        [JsonPropertyName("label")]
        public string Label { get; set; }

        [JsonPropertyName("pattern")]
        public string Pattern { get; set; }

        [JsonPropertyName("type")]
        public string Type { get; set; }
    }
}
