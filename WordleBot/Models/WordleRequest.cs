using System.Text.Json.Serialization;

namespace WordleBot.Models
{
    //public class WordleRequest
    //{
    //    public List<WordleRequestItem> WordleRequestItem { get; set; }
    //}

    //public class WordleRequestItem
    //{
    //    public string Word { get; set; }
    //    public string Clue { get; set; }
    //}

    public class WordleRequest
    {
        [JsonPropertyName("word")]
        public string Word { get; set; }
        [JsonPropertyName("clue")]
        public string Clue { get; set; }
    }
}
