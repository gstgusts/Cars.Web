using System.Text.Json.Serialization;

namespace Cars.Api.Models
{
    public class CarsByYearModel
    {
        [JsonPropertyName("cols")]
        public ColModel[] Cols { get; set; }

        [JsonPropertyName("rows")]
        public RowModel[] Rows { get; set; }
    }
}
