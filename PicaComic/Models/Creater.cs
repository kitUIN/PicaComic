namespace PicaComic.Models
{
    /// <summary>
    /// 漫画上传者
    /// </summary>
    /// <seealso cref="PicaComic.Models.User" />
    public class Creater: User
    {
        /// <summary>
        /// 身份
        /// </summary>
        [JsonPropertyName("role")]
        public string Role { get; set; }
        /// <summary>
        /// 个人签名
        /// </summary> 
        [JsonPropertyName("slogan")]
        public string Slogan { get; set; }

    }
}
