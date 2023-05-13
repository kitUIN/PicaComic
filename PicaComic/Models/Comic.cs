namespace PicaComic.Models
{
    public class Comic
    {
        [JsonPropertyName("_id")]
        public string Id { get; set; }

        [JsonPropertyName("title")]
        public string Title { get; set; }

        [JsonPropertyName("author")]
        public string Author { get; set; }

        [JsonPropertyName("pagesCount")]
        public int PagesCount { get; set; }

        [JsonPropertyName("epsCount")]
        public int EpsCount { get; set; }

        [JsonPropertyName("finished")]
        public bool Finished { get; set; }

        [JsonPropertyName("categories")]
        public List<string> Categories { get; set; }

        [JsonPropertyName("thumb")]
        public Thumb Thumb { get; set; }

        [JsonPropertyName("totalLikes")]
        public int TotalLikes { get; set; }

        [JsonPropertyName("totalViews")]
        public int TotalViews { get; set; }

        [JsonPropertyName("likesCount")]
        public int LikesCount { get; set; }
    }
}
