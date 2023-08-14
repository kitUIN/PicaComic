namespace PicaComic.Datas
{
    public class SearchResultData
    {
        [JsonPropertyName("comics")]
        public SearchResultList Comics { get; set; }
    }
}
