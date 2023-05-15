namespace PicaComic.Datas
{
    public class LeaderBoardData
    {
        [JsonPropertyName("comics")]
        public List<LeaderBoardComic> Comics { get; set; }
    }
}
