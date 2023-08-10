namespace PicaComic.Datas
{
    /// <summary>
    /// $.data
    /// </summary>
    public class CategoryComicListData
    {
        /// <summary>
        /// $.data.comics
        /// </summary>
        [JsonPropertyName("comics")]
        public CategoryComicList Comics { get; set; }
    }
}
