namespace PicaComic.Responses
{
    public class CollectionsResponse: PicaResponse
    {
        [JsonPropertyName("data")]
        public CollectionsData Data { get; set; }
    }
}
