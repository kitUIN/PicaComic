namespace PicaComic.Responses
{
    public class CategoryResponse : PicaResponse
    {
        [JsonPropertyName("data")]
        public CategoryComicListData Data { get; set; }
    }
}
