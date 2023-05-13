namespace PicaComic.Responses
{
    public class SignInResponse : PicaResponse
    {
        [JsonPropertyName("data")]
        public SignInData Data { get; set; }
    }
}

