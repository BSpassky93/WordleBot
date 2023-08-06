using System.Text.Json.Serialization;

namespace WordleBot.Models
{
    public class WordleResponse
    {
        [JsonPropertyName("guess")]
        public string Guess { get; set; }
    }
}
