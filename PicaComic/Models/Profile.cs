namespace PicaComic.Models
{
    /// <summary>
    /// 用户
    /// </summary>
    /// <seealso cref="PicaComic.Models.User" />
    public class Profile: User
    {
        /// <summary>
        /// 生日
        /// </summary>
        [JsonPropertyName("birthday")]
        public DateTime Birthday { get; set; }
        /// <summary>
        /// 邮箱地址
        /// </summary>
        [JsonPropertyName("email")]
        public string Email { get; set; }

        /// <summary>
        /// 个人签名
        /// </summary> 
        [JsonPropertyName("slogan")]
        public string Slogan { get; set; }

        [JsonPropertyName("created_at")]
        public DateTime CreatedAt { get; set; }

        [JsonPropertyName("isPunched")]
        public bool IsPunched { get; set; }

        [JsonPropertyName("character")]
        public string Character { get; set; }
    }
}
