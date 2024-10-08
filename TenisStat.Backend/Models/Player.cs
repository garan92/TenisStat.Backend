using System.Diagnostics.Metrics;
using System.Text.Json.Serialization;

namespace TenisStat.Backend.Models
{
    public class Player
    {
        [JsonPropertyName("id")]
        public int Id { get; set; }
        [JsonPropertyName("firstname")]
        public string Firstname { get; set; }
        [JsonPropertyName("lastname")]
        public string Lastname { get; set; }
        [JsonPropertyName("shortname")]
        public string Shortname { get; set; }
        [JsonPropertyName("sex")]
        public string Sex { get; set; }
        [JsonPropertyName("country")]
        public Country Country { get; set; }
        [JsonPropertyName("picture")]
        public string Picture { get; set; }
        [JsonPropertyName("data")]
        public PlayerData Data { get; set; }
    }
}
