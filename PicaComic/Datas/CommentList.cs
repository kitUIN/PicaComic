namespace PicaComic.Datas
{
    public class CommentList
    {
        [JsonPropertyName("docs")]
        public List<Comment> Docs { get; set; }

        [JsonPropertyName("total")]
        public int Total { get; set; }

        [JsonPropertyName("limit")]
        public int Limit { get; set; }

        [JsonPropertyName("page")]
        public string PageT { get; set; }

        [JsonPropertyName("pages")]
        public int Pages { get; set; }

        public int Page => int.Parse(PageT);
    }
}
