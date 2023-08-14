namespace PicaComic.Datas
{
    public class SearchResultList : ComicList
    {
        [JsonPropertyName("docs")]
        public List<CategoryComic> Docs { get; set; }
    }
}
