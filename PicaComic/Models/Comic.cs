using Windows.Services.Maps.LocalSearch;

namespace PicaComic.Models
{
    /// <summary>
    /// 漫画
    /// </summary>
    public class Comic
    {
        /// <summary>
        /// ID
        /// </summary>
        [JsonPropertyName("_id")]
        public string Id { get; set; }
        /// <summary>
        /// 漫画名
        /// </summary>
        [JsonPropertyName("title")]
        public string Title { get; set; }
        /// <summary>
        /// 作者
        /// </summary>
        [JsonPropertyName("author")]
        public string Author { get; set; }
        /// <summary>
        /// 是否完结
        /// </summary>
        [JsonPropertyName("finished")]
        public bool Finished { get; set; }
        /// <summary>
        /// 分类
        /// </summary>
        [JsonPropertyName("categories")]
        public List<string> Categories { get; set; }

        /// <summary>
        /// 缩略图
        /// </summary>
        [JsonPropertyName("thumb")]
        public Thumb Thumb { get; set; }
        /// <summary>
        /// 分类转string
        /// </summary>
        [JsonIgnore]
        public string CategoryString => Categories.ListString();
        /// <summary>
        /// 是否被封印
        /// </summary>
        [JsonIgnore]
        public bool IsLocked { get; set; } = false;
        /// <summary>
        /// 被封印的分区
        /// </summary>
        [JsonIgnore]
        public List<string> LockCategories { get; set; } = new List<string>();
        /// <summary>
        /// 被封印的分区文字版
        /// </summary>
        [JsonIgnore]
        public string LockCategoryString => LockCategories.ListString();
    }
}
