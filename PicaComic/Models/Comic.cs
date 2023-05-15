namespace PicaComic.Models
{
    /// <summary>
    /// 漫画
    /// </summary>
    public class Comic
    {
        [JsonPropertyName("_id")]
        public string Id { get; set; }

        [JsonPropertyName("title")]
        public string Title { get; set; }

        [JsonPropertyName("author")]
        public string Author { get; set; }

        [JsonPropertyName("finished")]
        public bool Finished { get; set; }

        [JsonPropertyName("categories")]
        public List<string> Categories { get; set; }

        [JsonPropertyName("thumb")]
        public Thumb Thumb { get; set; }
        
    }
}
