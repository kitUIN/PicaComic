namespace PicaComic.Responses
{
    public class ProfileResponse: PicaResponse
    {
        [JsonPropertyName("data")]
        public ProfileData Data { get; set; }
    }
}
