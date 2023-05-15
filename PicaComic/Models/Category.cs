namespace PicaComic.Models
{
    /// <summary>
    /// 分类
    /// </summary>
    public class Category
    {
        [JsonPropertyName("_id")]
        public string Id { get; set; }

        [JsonPropertyName("title")]
        public string Title { get; set; }

        [JsonPropertyName("description")]
        public string Description { get; set; }

        [JsonPropertyName("thumb")]
        public Thumb Thumb { get; set; }

        [JsonPropertyName("isWeb")]
        public bool IsWeb { get; set; }

        [JsonPropertyName("active")]
        public bool Active { get; set; }

        [JsonPropertyName("link")]
        public string Link { get; set; }
    }
}
