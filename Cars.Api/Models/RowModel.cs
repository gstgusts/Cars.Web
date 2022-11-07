using Newtonsoft.Json;
using System.Text.Json.Serialization;

namespace Cars.Api.Models
{
    public class RowModel
    {
        [JsonPropertyName("c")]
        public RowDataItem[] ColData { get; set; }
    }
}
