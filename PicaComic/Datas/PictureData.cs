namespace PicaComic.Datas
{
    public class PictureData
    {
        [JsonPropertyName("pages")]
        public PictureList Pages { get; set; }

        [JsonPropertyName("ep")]
        public Episode Ep { get; set; }
    }
}
