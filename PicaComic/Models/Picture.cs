
namespace PicaComic.Models
{
    public class Picture
    {
        [JsonPropertyName("_id")]
        public string Id { get; set; }

        [JsonPropertyName("media")]
        public Thumb Media { get; set; }

    }
}
