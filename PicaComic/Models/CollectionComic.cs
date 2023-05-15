namespace PicaComic.Models
{
    /// <summary>
    /// 神魔推荐漫画
    /// </summary>
    /// <seealso cref="PicaComic.Models.Comic" />
    public class CollectionComic: Comic
    {
        [JsonPropertyName("pagesCount")]
        public int PagesCount { get; set; }

        [JsonPropertyName("epsCount")]
        public int EpsCount { get; set; }
        [JsonPropertyName("totalLikes")]
        public int TotalLikes { get; set; }

        [JsonPropertyName("totalViews")]
        public int TotalViews { get; set; }
    }
}
