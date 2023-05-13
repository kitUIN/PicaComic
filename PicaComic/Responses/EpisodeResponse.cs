namespace PicaComic.Responses
{
    public class EpisodeResponse : PicaResponse
    {
        [JsonPropertyName("data")]
        public EpisodeList Data { get; set; }
    }
}
