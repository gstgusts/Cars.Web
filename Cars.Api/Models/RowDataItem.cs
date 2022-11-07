using System.Text.Json.Serialization;

namespace Cars.Api.Models
{
    public class RowDataItem
    {
        [JsonPropertyName("v")]
        public object Value { get; set; }

        [JsonPropertyName("f")]
        public string Format { get; set; }
    }
}
