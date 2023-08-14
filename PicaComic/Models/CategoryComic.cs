namespace PicaComic.Models
{
    public class CategoryComic: CollectionComic
    {
        [JsonPropertyName("likeCount")]
        public int LikeCount { get; set; }
        
        
    }
}
