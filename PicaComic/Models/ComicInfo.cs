using System.Collections.ObjectModel;
using CommunityToolkit.Mvvm.ComponentModel;

namespace PicaComic.Models;

/// <summary>
/// 漫画详细信息
/// </summary>
/// <seealso cref="PicaComic.Models.Comic" />
public partial class ComicInfo : Comic
{
    /// <summary>
    /// 总页数
    /// </summary>
    [ObservableProperty] [property: JsonPropertyName("pagesCount")]
    private int pagesCount;

    /// <summary>
    /// 总话数
    /// </summary>
    [ObservableProperty] [property: JsonPropertyName("epsCount")]
    private int epsCount;

    /// <summary>
    /// 总喜欢
    /// </summary>
    [ObservableProperty] [property: JsonPropertyName("totalLikes")]
    private int totalLikes;

    /// <summary>
    /// 总查看
    /// </summary>
    [ObservableProperty] [property: JsonPropertyName("totalViews")]
    private int totalViews;

    /// <summary>
    /// 喜欢数量
    /// </summary>
    [ObservableProperty] [property: JsonPropertyName("likesCount")]
    private int likesCount;

    /// <summary>
    /// 上传者
    /// </summary>
    [ObservableProperty] [property: JsonPropertyName("_creator")]
    private Creater creator;

    /// <summary>
    /// 介绍
    /// </summary>
    [ObservableProperty] [property: JsonPropertyName("description")]
    private string description;

    /// <summary>
    /// 汉化组
    /// </summary>
    [ObservableProperty] [property: JsonPropertyName("chineseTeam")]
    private string chineseTeam;

    /// <summary>
    /// 标签
    /// </summary>
    [JsonPropertyName("tags")] 
    public List<string> Tags { get; set; }

    /// <summary>
    /// 更新时间
    /// </summary>
    [ObservableProperty] [property: JsonPropertyName("updated_at")]
    private DateTime updatedAt;

    /// <summary>
    /// 上传时间
    /// </summary>
    [ObservableProperty] [property: JsonPropertyName("created_at")]
    private DateTime createdAt;

    /// <summary>
    /// 允许下载
    /// </summary>
    [ObservableProperty] [property: JsonPropertyName("allowDownload")]
    private bool allowDownload;

    /// <summary>
    /// 允许评论
    /// </summary>
    [ObservableProperty] [property: JsonPropertyName("allowComment")]
    private bool allowComment;

    /// <summary>
    /// 总评论
    /// </summary>
    [ObservableProperty] [property: JsonPropertyName("totalComments")]
    private int totalComments;

    /// <summary>
    /// 查看数量
    /// </summary>
    [ObservableProperty] [property: JsonPropertyName("viewsCount")]
    private int viewsCount;

    /// <summary>
    /// 评论数量
    /// </summary>
    [ObservableProperty] [property: JsonPropertyName("commentsCount")]
    private int commentsCount;

    /// <summary>
    /// 是否收藏
    /// </summary>
    [ObservableProperty] [property: JsonPropertyName("isFavourite")]
    private bool isFavourite;

    /// <summary>
    /// 是否喜欢
    /// </summary>
    [ObservableProperty] [property: JsonPropertyName("isLiked")]
    private bool isLiked;
}