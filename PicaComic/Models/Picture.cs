
namespace PicaComic.Models
{
    /// <summary>
    /// 漫画-页
    /// </summary>
    public class Picture
    {
        [JsonPropertyName("_id")]
        public string Id { get; set; }

        [JsonPropertyName("media")]
        public Thumb Media { get; set; }

    }
}
