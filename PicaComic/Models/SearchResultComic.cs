namespace PicaComic.Models
{
    public class SearchResultComic : Comic
    {

        [JsonPropertyName("description")]
        public string Description { get; set; }

        [JsonPropertyName("chineseTeam")]
        public string ChineseTeam { get; set; }

        [JsonPropertyName("tags")]
        public List<string> Tags { get; set; }

        [JsonPropertyName("updated_at")]
        public DateTime UpdatedAt { get; set; }

        [JsonPropertyName("created_at")]
        public DateTime CreatedAt { get; set; }

        [JsonPropertyName("likesCount")]
        public int LikesCount { get; set; }

    }
}
