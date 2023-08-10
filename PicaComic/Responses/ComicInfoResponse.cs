namespace PicaComic.Responses
{
    /// <summary>
    /// 漫画信息请求返回
    /// </summary>
    public class ComicInfoResponse: PicaResponse
    {
        /// <summary>
        /// $.data
        /// </summary>
        [JsonPropertyName("data")]
        public ComicInfoData Data { get; set; }
    }
}
