namespace PicaComic.Models
{
    public class LeaderBoardComic : CollectionComic
    {
        [JsonPropertyName("viewsCount")]
        public int ViewsCount { get; set; }

        [JsonPropertyName("leaderboardCount")]
        public int LeaderboardCount { get; set; }
    }
}
