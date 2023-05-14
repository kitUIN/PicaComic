namespace PicaComic.Models
{
    public class Collection
    {
        [JsonPropertyName("title")]
        public string Title { get; set; }
        [JsonPropertyName("comics")]
        public List<Comic> Comics { get; set; }
    }
}
