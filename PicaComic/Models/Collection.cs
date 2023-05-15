namespace PicaComic.Models
{
    /// <summary>
    /// 神魔推荐
    /// </summary>
    public class Collection
    {
        [JsonPropertyName("title")]
        public string Title { get; set; }
        [JsonPropertyName("comics")]
        public List<CollectionComic> Comics { get; set; }
    }
}
