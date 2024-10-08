using System.Text.Json.Serialization;

namespace TenisStat.Backend.Models
{
    public class PlayerList
    {
        [JsonPropertyName("players")]
        public List<Player> Players { get; set; }
    }
}
