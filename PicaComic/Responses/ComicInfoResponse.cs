namespace PicaComic.Responses
{
    public class ComicInfoResponse:PicaResponse
    {
        [JsonPropertyName("data")]
        public ComicInfo Data { get; set; }
    }
}
