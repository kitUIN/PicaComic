namespace PicaComic.Responses
{
    public class CommentResponse: PicaResponse
    {
        [JsonPropertyName("data")]
        public CommentsData Data { get; set; }
    }
}
