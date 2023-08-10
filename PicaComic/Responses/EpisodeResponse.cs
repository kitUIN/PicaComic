namespace PicaComic.Responses
{
    /// <summary>
    /// 话 请求返回
    /// </summary>
    public class EpisodeResponse : PicaResponse
    {
        /// <summary>
        /// $.data
        /// </summary>
        [JsonPropertyName("data")]
        public EpisodeListData Data { get; set; }
    }
}
