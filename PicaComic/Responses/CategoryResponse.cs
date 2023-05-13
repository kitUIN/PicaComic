namespace PicaComic.Responses
{
    public class CategoryResponse : PicaResponse
    {
        [JsonPropertyName("data")]
        public ComicList Data { get; set; }
    }
}
