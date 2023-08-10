namespace PicaComic.Responses
{
    /// <summary>
    /// 分区,推荐本子的返回
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
