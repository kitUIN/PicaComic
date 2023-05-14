namespace PicaComic.Datas
{
    public class CollectionsData
    {
        [JsonPropertyName("collections")]
        public List<Collection> Collection { get; set; }
    }
}
