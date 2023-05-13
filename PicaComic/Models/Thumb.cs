namespace PicaComic.Models
{
    public class Thumb
    {
        [JsonPropertyName("originalName")]
        public string OriginalName { get; set; }

        [JsonPropertyName("path")]
        public string Path { get; set; }

        [JsonPropertyName("fileServer")]
        public string FileServer { get; set; }
    }
}
