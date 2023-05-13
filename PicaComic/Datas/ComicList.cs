namespace PicaComic.Datas
{
    public class ComicList
    {
        [JsonPropertyName("docs")]
        public List<Comic> Docs { get; set; }

        [JsonPropertyName("total")]
        public int Total { get; set; }

        [JsonPropertyName("limit")]
        public int Limit { get; set; }

        [JsonPropertyName("page")]
        public int Page { get; set; }

        [JsonPropertyName("pages")]
        public int Pages { get; set; }
    }
}
