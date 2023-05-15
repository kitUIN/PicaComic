namespace PicaComic.Datas
{
    public class SearchResultList : ComicList
    {
        [JsonPropertyName("docs")]
        public List<SearchResultComic> Docs { get; set; }
    }
}
