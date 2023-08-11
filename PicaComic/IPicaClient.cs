namespace PicaComic;
/// <summary>
/// IPicaClient
/// </summary>
public interface IPicaClient
{
    /// <summary>
    /// 分流
    /// </summary>
    public static int AppChannel { get; set; } = 3;

    /// <summary>
    /// 图片分流
    /// </summary>
    public static int FileChannel { get; set; } = 3;

    /// <summary>
    /// 图片分流服务器
    /// </summary>
    public static  IReadOnlyList<string> FileServer{ get; } = new List<string>
        { "https://storage1.picacomic.com/", "https://s2.picacomic.com/", "https://s3.picacomic.com/" };

    /// <summary>
    /// 设置登录凭证
    /// </summary>
    /// <param name="t">登录凭证</param>
    void SetToken(string t);

    /// <summary>
    /// 是否存在登录凭证
    /// </summary>
    bool HasToken { get; }

    /// <summary>
    /// 重置代理
    /// </summary>
    void ResetProxy();

    /// <summary>
    /// 设置超时时间
    /// </summary>
    void SetTimeout(double timeout);

    /// <summary>
    /// 设置代理,仅支持'http', 'socks4', 'socks4a', 'socks5'
    /// </summary>
    /// <param name="p">Proxy Address</param>
    void SetProxy(Uri p);

    /// <summary>
    /// 连接测试
    /// </summary>
    /// <returns>所需要的时间(单位ms)</returns>
    Task<int> PingBaseUrl();

    /// <summary>
    /// 连接测试
    /// </summary>
    /// <param name="url">The URL.</param>
    /// <returns>所需要的时间(单位ms)</returns>
    Task<int> Ping(string url);

    /// <summary>
    /// 登录接口
    /// </summary>
    /// <param name="email"></param>
    /// <param name="password"></param>
    /// <exception cref="PicaComicException"></exception> 
    /// <returns></returns>
    Task<SignInResponse> SignIn(string email, string password);

    /// <summary>
    /// 获取用户资料接口
    /// </summary>
    /// <param name="id"></param>
    /// <exception cref="PicaComicException"></exception> 
    /// <returns></returns>
    Task<ProfileResponse> Profile(string id = null);

    /// <summary>
    /// 大家都在搜 接口
    /// </summary>
    /// <returns></returns>
    Task<KeywordsResponse> Keywords();

    /// <summary>
    /// 看过这篇的也看 接口
    /// </summary>
    /// <param name="comicId">The book identifier.</param>
    /// <returns></returns>
    Task<ComicRandomResponse> Recommendation(string comicId);

    /// <summary>
    /// 获取所有分区 接口
    /// </summary>
    Task<CategoriesResponse> Categories();

    /// <summary>
    /// 获取分区内漫画 接口
    /// </summary>
    /// <param name="category">分区名称<see cref="Category.Title"/></param>
    /// <param name="page">第几页</param>
    /// <param name="s">default: <see cref="SortRule.dd"/></param>
    Task<CategoryResponse> Category(string category, int page = 1, SortRule s = SortRule.dd);

    /// <summary>
    /// 随机本子接口
    /// </summary>
    Task<ComicRandomResponse> ComicRandom();

    /// <summary>
    /// 神魔推荐
    /// </summary>
    /// <returns></returns>
    Task<CollectionsResponse> ComicCollections();

    /// <summary>
    /// 获取漫画详细信息 接口
    /// </summary> 
    /// <param name="comicId">漫画ID<see cref="Comic.Id"/></param>
    /// <returns></returns>
    Task<ComicInfoResponse> ComicInfo(string comicId);

    /// <summary>
    /// 获取话 接口
    /// </summary> 
    /// <param name="comicId">漫画ID<see cref="Comic.Id"/></param>
    /// <param name="page">第几页</param>
    /// <returns></returns>
    Task<EpisodeResponse> Episodes(string comicId, int page);


    /// <summary>
    /// 获取图片合集 接口
    /// </summary>
    /// <param name="comicId">漫画ID<see cref="Comic.Id"/></param>
    /// <param name="epsId">话Order<see cref="Episode.Order"/></param>
    /// <param name="page">第几页</param>
    /// <returns></returns>
    Task<PictureResponse> Pictures(string comicId, int epsId, int page);

    /// <summary>
    /// 获得漫画评论 接口
    /// </summary>
    /// <param name="comicId">漫画ID</param>
    /// <param name="page">第几页</param>
    /// <returns></returns>
    Task<CommentResponse> ComicComments(string comicId, int page);

    /// <summary>
    /// 获得自己的评论 接口
    /// </summary>
    /// <param name="page">第几页</param>
    /// <returns></returns>
    Task<CommentResponse> ProfileComments(int page);

    /// <summary>
    /// 修改密码 接口
    /// </summary>
    /// <param name="newPassword">新密码</param>
    /// <param name="oldPassword">旧密码</param>
    /// <returns></returns>
    Task<PicaResponse> ChangePassword(string newPassword, string oldPassword);

    /// <summary>
    /// 修改头像 接口
    /// </summary>
    /// <param name="imgData">base64图片</param>
    /// <returns></returns>
    Task<PicaResponse> SetAvatar(string imgData);

    /// <summary>
    /// 修改头像 接口
    /// </summary>
    /// <param name="img">图片</param>
    /// <returns></returns>
    Task<PicaResponse> SetAvatar(StorageFile img);

    /// <summary>
    /// 签到 接口
    /// </summary>
    /// <returns></returns>
    Task<PunchInResponse> PunchIn();

    /// <summary>
    /// 个人收藏 接口
    /// </summary>
    /// <param name="page">第几页</param>
    /// <param name="s">排序<see cref="SortRule"/></param>
    Task<CategoryResponse> ProfileFavourites(int page, SortRule s = SortRule.dd);

    /// <summary>
    /// 把漫画添加到个人收藏 接口
    /// </summary>
    /// <param name="comicId">漫画ID</param>
    Task<ActionResponse> ComicFavourite(string comicId);

    /// <summary>
    /// 给漫画加爱心 接口
    /// </summary>
    /// <param name="comicId">漫画ID</param>
    Task<ActionResponse> ComicLike(string comicId);

    /// <summary>
    /// 高级搜索 接口
    /// </summary>
    /// <param name="categories">分区</param>
    /// <param name="keyword">关键词</param>
    /// <param name="page">第几页</param>
    /// <param name="s">排序<see cref="SortRule"/></param>
    /// <returns></returns>
    Task<SearchResultResponse> AdvancedSearch(string keyword, int page,
        SortRule s = SortRule.dd, List<string> categories = null);

    /// <summary>
    /// 获取评论的评论 接口
    /// </summary>
    /// <param name="commentId">评论ID</param>
    /// <param name="page">第几页</param>
    /// <returns></returns>
    Task<CommentResponse> CommentChildren(string commentId, int page);

    /// <summary>
    /// 喜欢一个评论 接口
    /// </summary>
    /// <param name="commentId">评论ID</param>
    Task<ActionResponse> CommentLike(string commentId);

    /// <returns></returns>
    /// <summary>
    /// 发送漫画评论 接口
    /// </summary>
    /// <param name="comicId">漫画ID</param>
    /// <param name="message">评论</param>
    /// <returns></returns>
    Task<PicaResponse> SendComicComment(string comicId, string message);

    /// <summary>
    /// 发送子评论 接口
    /// </summary>
    /// <param name="commentId">评论ID</param>
    /// <param name="message">评论</param>
    /// <returns></returns>
    Task<PicaResponse> SendCommentChildren(string commentId, string message);

    /// <summary>
    /// 骑士榜
    /// </summary>
    /// <returns></returns>
    Task<KnightsResponse> KnightLeaderboard();

    /// <summary>
    /// 排行榜
    /// </summary>
    /// <param name="tt"><see cref="LeaderboardTime"/>时间区间</param>
    /// <returns></returns>
    Task<LeaderBoardResponse> Leaderboard(LeaderboardTime tt = LeaderboardTime.H24);
}