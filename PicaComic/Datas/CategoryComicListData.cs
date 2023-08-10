namespace PicaComic.Datas
{
    /// <summary>
    /// CategoryComicListData
    /// </summary>
    public class CategoryComicListData
    {
        /// <summary>
        /// $.comics
        /// </summary>
        [JsonPropertyName("comics")]
        public CategoryComicList Comics { get; set; }
    }
}
