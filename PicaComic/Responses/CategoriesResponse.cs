namespace PicaComic.Responses
{
    public class CategoriesResponse : PicaResponse
    {
        [JsonPropertyName("data")]
        public CategoriesData Data { get; set; }
    }
}
