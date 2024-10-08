using System.Text.Json.Serialization;

namespace TenisStat.Backend.Models
{
    public class Country
    {
        [JsonPropertyName("picture")]
        public string Picture { get; set; }
        [JsonPropertyName("code")]
        public string Code { get; set; }
    }
}
