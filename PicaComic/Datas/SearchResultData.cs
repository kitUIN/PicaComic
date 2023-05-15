namespace PicaComic.Datas
{
    public class SearchResultData
    {
        [JsonPropertyName("data")]
        public SearchResultList Data { get; set; }
    }
}
