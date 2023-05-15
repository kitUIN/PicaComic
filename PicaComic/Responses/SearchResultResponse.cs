namespace PicaComic.Responses
{
    public class SearchResultResponse : PicaResponse
    {
        [JsonPropertyName("data")]
        public SearchResultData Data { get; set; }
    }
}