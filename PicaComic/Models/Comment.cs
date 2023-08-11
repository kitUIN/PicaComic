using System.Collections.ObjectModel;
using CommunityToolkit.Mvvm.ComponentModel;

namespace PicaComic.Models
{
    /// <summary>
    /// 评论
    /// </summary>
    public partial class Comment: ObservableObject
    {   
        /// <summary>
        /// 评论Id
        /// </summary>
        [ObservableProperty] [property: JsonPropertyName("_id")]
        private string id ;
        /// <summary>
        /// 评论内容
        /// </summary>
        [ObservableProperty] [property: JsonPropertyName("content")]
        private string content ;
        /// <summary>
        /// 评论者
        /// </summary>
        [ObservableProperty] [property: JsonPropertyName("_user")]
        private Commenter user ;
        /// <summary>
        /// 漫画ID
        /// </summary>
        [ObservableProperty] [property: JsonPropertyName("_comic")]
        private string comic ;
        /// <summary>
        /// 评论数量
        /// </summary>
        [ObservableProperty] [property: JsonPropertyName("totalComments")]
        private int totalComments ;
        /// <summary>
        /// 是否置顶
        /// </summary>
        [ObservableProperty] [property: JsonPropertyName("isTop")]
        private bool isTop ;
        /// <summary>
        /// 是否隐藏
        /// </summary>
        [ObservableProperty] [property: JsonPropertyName("hide")]
        private bool isHide ;
        /// <summary>
        /// 创建时间
        /// </summary>
        [ObservableProperty] [property: JsonPropertyName("created_at")]
        private DateTime createdAt ;
        /// <summary>
        /// 喜欢数量
        /// </summary>
        [ObservableProperty] [property: JsonPropertyName("likesCount")]
        private int likesCount ;
        /// <summary>
        /// 评论数量
        /// </summary>
        [ObservableProperty] [property: JsonPropertyName("commentsCount")]
        private int commentsCount ;
        /// <summary>
        /// 是否喜欢
        /// </summary>
        [ObservableProperty] [property: JsonPropertyName("isLiked")]
        private bool isLiked ;
        /// <summary>
        /// 第几楼
        /// </summary>
        [ObservableProperty] [property: JsonIgnore]
        private int order;
        /// <summary>
        /// 是否显示子评论
        /// </summary>
        [ObservableProperty] [property: JsonIgnore]
        private bool isShowChildren;
        /// <summary>
        /// 子评论
        /// </summary>
        public ObservableCollection<Comment> Children { get; } = new ObservableCollection<Comment>();
    }



















}
