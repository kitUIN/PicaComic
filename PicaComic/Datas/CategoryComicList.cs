namespace PicaComic.Datas
{
    /// <summary>
    /// CategoryComicList
    /// </summary>
    public class CategoryComicList: ComicList
    {
        /// <summary>
        /// $.docs
        /// </summary>
        [JsonPropertyName("docs")]
        public List<CategoryComic> Docs { get; set; }
    }
}
