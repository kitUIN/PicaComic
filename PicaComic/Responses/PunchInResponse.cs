namespace PicaComic.Responses
{
    public class PunchInResponse: PicaResponse
    {
        [JsonPropertyName("data")]
        public PunchInData Data { get; set; }
    }
}
