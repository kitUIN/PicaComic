namespace PicaComic.Responses
{
    public class PictureResponse : PicaResponse
    {
        [JsonPropertyName("data")]
        public PictureData Data { get; set; }
    }
}
