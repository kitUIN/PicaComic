namespace PicaComic.Datas
{
    /// <summary>
    /// $.data.eps
    /// </summary>
    public class EpisodeList
    {
        /// <summary>
        /// $.data.eps.docs
        /// </summary>
        [JsonPropertyName("docs")]
        public List<Episode> Docs { get; set; }
        /// <summary>
        /// $.data.eps.total
        /// </summary>
        [JsonPropertyName("total")]
        public int Total { get; set; }
        /// <summary>
        /// $.data.eps.limit
        /// </summary>
        [JsonPropertyName("limit")]
        public int Limit { get; set; }
        /// <summary>
        /// $.data.eps.page
        /// </summary>
        [JsonPropertyName("page")]
        public int Page { get; set; }
        /// <summary>
        /// $.data.eps.pages
        /// </summary>
        [JsonPropertyName("pages")]
        public int Pages { get; set; }
    }
}
