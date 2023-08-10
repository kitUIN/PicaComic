namespace PicaComic.Datas
{
    /// <summary>
    /// $.data.comics
    /// </summary>
    public class CategoryComicList: ComicList
    {
        /// <summary>
        /// $.data.comics.docs
        /// </summary>
        [JsonPropertyName("docs")]
        public List<CategoryComic> Docs { get; set; }
    }
}
