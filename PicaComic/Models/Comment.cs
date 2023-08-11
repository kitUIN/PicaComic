using CommunityToolkit.Mvvm.ComponentModel;

namespace PicaComic.Models
{
    /// <summary>
    /// 评论
    /// </summary>
    public partial class Comment: ObservableObject
    {
        [ObservableProperty] [property: JsonPropertyName("_id")]
        private string id ;

        [ObservableProperty] [property: JsonPropertyName("content")]
        private string content ;

        [ObservableProperty] [property: JsonPropertyName("_user")]
        private Commenter user ;

        [ObservableProperty] [property: JsonPropertyName("_comic")]
        private string comic ;

        [ObservableProperty] [property: JsonPropertyName("totalComments")]
        private int totalComments ;

        [ObservableProperty] [property: JsonPropertyName("isTop")]
        private bool isTop ;

        [ObservableProperty] [property: JsonPropertyName("hide")]
        private bool hide ;

        [ObservableProperty] [property: JsonPropertyName("created_at")]
        private DateTime createdAt ;

        [ObservableProperty] [property: JsonPropertyName("likesCount")]
        private int likesCount ;

        [ObservableProperty] [property: JsonPropertyName("commentsCount")]
        private int commentsCount ;

        [ObservableProperty] [property: JsonPropertyName("isLiked")]
        private bool isLiked ;
        [ObservableProperty] [property: JsonIgnore]
        private int order;
    }



















}
