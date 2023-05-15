namespace PicaComic.Datas
{
    public class CategoryComicList: ComicList
    {
        [JsonPropertyName("docs")]
        public List<CategoryComic> Docs { get; set; }
    }
}
