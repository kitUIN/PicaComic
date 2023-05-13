namespace PicaComic.Responses
{
    public class KeywordsResponse: PicaResponse
    {
        [JsonPropertyName("data")]
        public KeywordsData Data { get; set; }
    }
}
