namespace PicaComic.Models
{
    /// <summary>
    /// 缩略图
    /// </summary>
    public class Thumb
    {
        [JsonPropertyName("originalName")]
        public string OriginalName { get; set; }

        [JsonPropertyName("path")]
        public string Path { get; set; }

        [JsonPropertyName("fileServer")]
        public string FileServer { get; set; }

        public string FilePath => $"{PicaClient.FileServer[PicaClient.FileChannel - 1]}static/{Path}";
    }
}
