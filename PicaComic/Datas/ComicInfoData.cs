namespace PicaComic.Datas
{
    /// <summary>
    /// $.data
    /// </summary>
    public class ComicInfoData
    {
        /// <summary>
        /// $.comic
        /// </summary>
        [JsonPropertyName("comic")]
        public ComicInfo Comic { get; set; }
    }
}
