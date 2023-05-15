using PicaComic.Utils;

namespace PicaComic.Models
{
    /// <summary>
    ///  骑士
    /// </summary>
    /// <seealso cref="PicaComic.Models.User" />
    public class Knight: User
    {
        /// <summary>
        /// 个人签名
        /// </summary> 
        [JsonPropertyName("slogan")]
        public string Slogan { get; set; }

        /// <summary>
        /// 头像框
        /// </summary>
        [JsonPropertyName("character")]
        public string Character { get; set; }

        /// <summary>
        /// 身份
        /// </summary>
        [JsonPropertyName("role")]
        public string Role { get; set; }

        /// <summary>
        /// 上传漫画数量
        /// </summary> 
        [JsonPropertyName("comicsUploaded")]
        public int ComicsUploaded { get; set; }
    }
}
