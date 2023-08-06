namespace PicaComic.Models
{
    /// <summary>
    /// 分类
    /// </summary>
    public class Category
    {
        /// <summary>
        /// ID
        /// </summary>
        [JsonPropertyName("_id")]
        public string Id { get; set; }
        /// <summary>
        /// 标题,也作为进入分区列表的参数名
        /// </summary>
        [JsonPropertyName("title")]
        public string Title { get; set; }
        /// <summary>
        /// 介绍
        /// </summary>
        [JsonPropertyName("description")]
        public string Description { get; set; }
        /// <summary>
        /// 缩略图
        /// </summary>
        [JsonPropertyName("thumb")]
        public Thumb Thumb { get; set; }
        /// <summary>
        /// 是否是Web端,可能没有值
        /// </summary>
        [JsonPropertyName("isWeb")]
        public bool IsWeb { get; set; }
        /// <summary>
        /// 是否启用(仅在IsWeb有值时判断),可能没有值
        /// </summary>
        [JsonPropertyName("active")]
        public bool Active { get; set; }
        /// <summary>
        /// Web链接,可能没有值
        /// </summary>
        [JsonPropertyName("link")]
        public string Link { get; set; }
    }
}
