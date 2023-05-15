namespace PicaComic.Datas
{
    public class SearchData
    {
        [JsonPropertyName("categories")]
        public List<string> Categories { get; set; }
        [JsonPropertyName("keyword")]
        public string Keyword { get; set; }
        [JsonPropertyName("sort")]
        public string Sort { get; set; }
    }
}
