using CommunityToolkit.Mvvm.ComponentModel;

namespace PicaComic.Models
{
    /// <summary>
    /// 评论
    /// </summary>
    public partial class Comment:ObservableObject
    {
        [JsonPropertyName("_id")]
        public string Id { get; set; }

        [JsonPropertyName("content")]
        public string Content { get; set; }

        [JsonPropertyName("_user")]
        public Commenter User { get; set; }

        [JsonPropertyName("_comic")]
        public string Comic { get; set; }

        [JsonPropertyName("totalComments")]
        public int TotalComments { get; set; }

        [JsonPropertyName("isTop")]
        public bool IsTop { get; set; }

        [JsonPropertyName("hide")]
        public bool Hide { get; set; }

        [JsonPropertyName("created_at")]
        public DateTime CreatedAt { get; set; }

        [JsonPropertyName("likesCount")]
        public int LikesCount { get; set; }

        [JsonPropertyName("commentsCount")]
        public int CommentsCount { get; set; }

        [JsonPropertyName("isLiked")]
        public bool IsLiked { get; set; }
        [ObservableProperty]
        private int order;
    }



















}
