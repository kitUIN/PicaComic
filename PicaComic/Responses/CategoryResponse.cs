namespace PicaComic.Responses
{
    /// <summary>
    /// 分区 请求返回
    /// </summary>
    public class CategoryResponse : PicaResponse
    {
        /// <summary>
        /// $.data
        /// </summary>
        [JsonPropertyName("data")]
        public CategoryComicListData Data { get; set; }
    }
}
