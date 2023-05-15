namespace PicaComic.Models
{
    /// <summary>
    /// 评论者
    /// </summary>
    /// <seealso cref="PicaComic.Models.User" />
    public class Commenter:User
    {
        /// <summary>
        /// 身份
        /// </summary>
        [JsonPropertyName("role")]
        public string Role { get; set; }
        /// <summary>
        /// 头像框
        /// </summary>
        [JsonPropertyName("character")]
        public string Character { get; set; }
    }
}
