namespace PicaComic.Responses
{
    public class LeaderBoardResponse : PicaResponse
    {
        [JsonPropertyName("data")]
        public LeaderBoardData Data { get; set; }
    }
}
