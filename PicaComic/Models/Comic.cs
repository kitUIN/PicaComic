﻿using CommunityToolkit.Mvvm.ComponentModel;
using Windows.Services.Maps.LocalSearch;

namespace PicaComic.Models;

/// <summary>
/// 漫画
/// </summary>
public partial class Comic : ObservableObject
{
    #region private

    private bool isLocked;
    private string lockCategoryString;
    private List<string> lockCategories;

    #endregion

    /// <summary>
    /// ID
    /// </summary>
    [ObservableProperty] [property: JsonPropertyName("_id")]
    private string id;

    /// <summary>
    /// 漫画名
    /// </summary>
    [ObservableProperty] [property: JsonPropertyName("title")]
    private string title;

    /// <summary>
    /// 作者
    /// </summary>
    [ObservableProperty] [property: JsonPropertyName("author")]
    private string author;

    /// <summary>
    /// 是否完结
    /// </summary>
    [ObservableProperty] [property: JsonPropertyName("finished")]
    private bool finished;

    /// <summary>
    /// 分类
    /// </summary>
    [ObservableProperty] [property: JsonPropertyName("categories")]
    private List<string> categories;

    /// <summary>
    /// 缩略图
    /// </summary>
    [ObservableProperty] [property: JsonPropertyName("thumb")]
    private Thumb thumb;

    /// <summary>
    /// 分类转string
    /// </summary>
    [JsonIgnore]
    public string CategoryString => Categories.ListString();

    /// <summary>
    /// 是否被封印
    /// </summary>
    [JsonIgnore]
    public bool IsLocked
    {
        get => isLocked;
        set
        {
            if (IsLocked != value) SetProperty(ref isLocked, value);
        }
    }

    /// <summary>
    /// 被封印的分区
    /// </summary>
    [JsonIgnore]
    public List<string> LockCategories
    {
        get => lockCategories;
        set
        {
            if (lockCategories == value) return;
            SetProperty(ref lockCategories, value);
            LockCategoryString = value.ListString();
        }
    }

    /// <summary>
    /// 被封印的分区文字版
    /// </summary>
    [JsonIgnore]
    public string LockCategoryString
    {
        get => lockCategoryString;
        set
        {
            if (LockCategoryString != value) SetProperty(ref lockCategoryString, value);
        }
    }
}