namespace PicaComic.Models
{
    /// <summary>
    /// 缩略图
    /// </summary>
    public class Thumb
    {
        /// <summary>
        /// 原始名称
        /// </summary>
        [JsonPropertyName("originalName")]
        public string OriginalName { get; set; }
        /// <summary>
        /// 原始地址
        /// </summary>
        [JsonPropertyName("path")]
        public string Path { get; set; }
        /// <summary>
        /// 图片服务器
        /// </summary>
        [JsonPropertyName("fileServer")]
        public string FileServer { get; set; }
        /// <summary>
        /// 自定义路径
        /// </summary>
        private string _path;
        /// <summary>
        /// 图片地址
        /// </summary>
        [JsonIgnore]
        public string FilePath { 
            get 
            {
                if (string.IsNullOrEmpty(_path))
                {
                    return $"{PicaClient.FileServer[PicaClient.FileChannel - 1]}static/{Path}";
                }
                return _path;
            } 
            set 
            {
                _path=value;
            } 
        }
    }
}
