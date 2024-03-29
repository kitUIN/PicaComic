﻿
namespace PicaComic.Models
{
    /// <summary>
    /// 漫画-话
    /// </summary>
    public class Episode
    {
        [JsonPropertyName("_id")]
        public string Id { get; set; }

        [JsonPropertyName("title")]
        public string Title { get; set; }

        [JsonPropertyName("order")]
        public int Order { get; set; }

        [JsonPropertyName("updated_at")]
        public DateTime UpdatedAt { get; set; }

    }


}
