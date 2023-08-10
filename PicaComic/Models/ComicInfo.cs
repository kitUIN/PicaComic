using System.Collections.ObjectModel;

namespace PicaComic.Models
{
    /// <summary>
    /// 漫画详细信息
    /// </summary>
    /// <seealso cref="PicaComic.Models.Comic" />
    public class ComicInfo: Comic
    {
        /// <summary>
        /// 总页数
        /// </summary>
        [JsonPropertyName("pagesCount")]
        public int PagesCount { get; set; }

        /// <summary>
        /// 总话数
        /// </summary>
        [JsonPropertyName("epsCount")]
        public int EpsCount { get; set; }
        /// <summary>
        /// 总喜欢
        /// </summary>
        [JsonPropertyName("totalLikes")]
        public int TotalLikes { get; set; }
        /// <summary>
        /// 总查看
        /// </summary>
        [JsonPropertyName("totalViews")]
        public int TotalViews { get; set; }
        /// <summary>
        /// 喜欢数量
        /// </summary>
        [JsonPropertyName("likesCount")]
        public int LikesCount { get; set; }
        /// <summary>
        /// 上传者
        /// </summary>
        [JsonPropertyName("_creator")]
        public Creater Creator { get; set; }
        /// <summary>
        /// 介绍
        /// </summary>
        [JsonPropertyName("description")]
        public string Description { get; set; }
        /// <summary>
        /// 汉化组
        /// </summary>
        [JsonPropertyName("chineseTeam")]
        public string ChineseTeam { get; set; }
        /// <summary>
        /// 标签
        /// </summary>
        [JsonPropertyName("tags")]
        public List<string> Tags { get; set; }

        /// <summary>
        /// 更新时间
        /// </summary>
        [JsonPropertyName("updated_at")]
        public DateTime UpdatedAt { get; set; }
        /// <summary>
        /// 上传时间
        /// </summary>
        [JsonPropertyName("created_at")]
        public DateTime CreatedAt { get; set; }
        /// <summary>
        /// 允许下载
        /// </summary>
        [JsonPropertyName("allowDownload")]
        public bool AllowDownload { get; set; }
        /// <summary>
        /// 允许评论
        /// </summary>
        [JsonPropertyName("allowComment")]
        public bool AllowComment { get; set; }
        /// <summary>
        /// 总评论
        /// </summary>
        [JsonPropertyName("totalComments")]
        public int TotalComments { get; set; }
        /// <summary>
        /// 查看数量
        /// </summary>
        [JsonPropertyName("viewsCount")]
        public int ViewsCount { get; set; }
        /// <summary>
        /// 评论数量
        /// </summary>
        [JsonPropertyName("commentsCount")]
        public int CommentsCount { get; set; }
        /// <summary>
        /// 是否收藏
        /// </summary>
        [JsonPropertyName("isFavourite")]
        public bool IsFavourite { get; set; }
        /// <summary>
        /// 是否喜欢
        /// </summary>
        [JsonPropertyName("isLiked")]
        public bool IsLiked { get; set; }
    }


















}
