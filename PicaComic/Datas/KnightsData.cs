namespace PicaComic.Datas
{
    public class KnightsData
    {
        [JsonPropertyName( "users")]
        public List<Knight> Data { get; set; }
    }
}
