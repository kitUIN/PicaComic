namespace PicaComic.Datas
{
    public class CategoriesData
    {
        [JsonPropertyName("categories")]
        public List<Category> Categories { get; set; }
    }
}
