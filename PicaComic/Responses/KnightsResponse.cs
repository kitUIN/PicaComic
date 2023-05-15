namespace PicaComic.Responses
{
    public class KnightsResponse : PicaResponse
    {
        [JsonPropertyName("data")]
        public KnightsData Data { get; set; }
    }
}
