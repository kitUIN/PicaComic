namespace PicaComic.Responses
{
    public class ActionResponse:PicaResponse
    {
        [JsonPropertyName("data")]
        public ActionData Data { get; set; }
    }
}
