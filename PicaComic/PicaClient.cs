using System.IO;

namespace PicaComic
{
    /// <summary>
    /// 哔咔漫画Http客户端
    /// </summary>
    public class PicaClient:IPicaClient
    {
        #region Fields

        /// <summary>
        /// 超时
        /// </summary>
        private double Timeout { get; set; } = 3;

        /// <summary>
        /// HttpClient实例
        /// </summary>
        private HttpClient client = new(new HttpClientHandler());

        /// <summary>
        /// 端口
        /// </summary>
        private WebProxy proxy;

        /// <summary>
        /// 登录凭证
        /// </summary>
        private string token;

        
        /// <summary>
        /// 服务器
        /// </summary>
        private const string BaseUrl = "https://picaapi.picacomic.com/";

        /// <summary>
        /// App 版本号
        /// </summary>
        public const string AppVersion = "2.2.1.3.3.4";

        /// <summary>
        /// The API key
        /// </summary>
        private const string ApiKey = "C69BAF41DA5ABD1FFEDC6D2FEA56B";

        /// <summary>
        /// The sign key
        /// </summary>
        private const string SignKey = @"~d}$Q7$eIni=V)9\RK/P.RM4;9[7|@/CA}b~OW!3?EV`:<>M7pddUBL5n|0/*Cn";

        /// <summary>
        /// UUID
        /// </summary>
        private  readonly string nonce = Guid.NewGuid().ToString().Replace("-", string.Empty);
        /// <summary>
        /// 初始化
        /// </summary>
        public PicaClient()
        {
            SetTimeout(Timeout);
        }

        #endregion

        #region Private Http

        /// <summary>
        /// 设置哔咔请求Header
        /// </summary>
        /// <param name="api">api name</param>
        /// <param name="method">http method</param>
        /// <returns></returns>
        private Dictionary<string, string> GetHeader(string api, string method)
        {
            var t = DateTimeOffset.Now.ToUnixTimeSeconds().ToString();
            var header = new Dictionary<string, string>
            {
                { "image-quality", "original" },
                { "api-key", ApiKey },
                { "accept", "application/vnd.picacomic.com.v1+json" },
                { "app-channel", IPicaClient.AppChannel.ToString() },
                { "time", t },
                { "app-version", AppVersion },
                { "nonce", nonce },
                { "app-uuid", "defaultUuid" },
                { "app-platform", "android" },
                { "app-build-version", "45" },
                { "User-Agent", "okhttp/3.8.1" },
                { "signature", HmacSha256(api + t + nonce + method + ApiKey, SignKey) },
            };
            if (token != null)
            {
                header.Add("authorization", token);
            }

            return header;
        }

        /// <summary>
        /// HmacSHA256 加密
        /// </summary>
        /// <param name="secret">text need to encrypt</param>
        /// <param name="signKey">signKey</param>
        /// <returns>hex ciphertext</returns>
        private static string HmacSha256(string secret, string signKey)
        {
            var signRet = string.Empty;
            using var mac = new HMACSHA256(Encoding.UTF8.GetBytes(signKey));
            var hash = mac.ComputeHash(Encoding.UTF8.GetBytes(secret.ToLower()));
            return  System.Convert.ToHexString(hash).ToLower();
        }

        /// <summary>
        /// 创建HttpRequestMessage
        /// </summary>
        /// <param name="method"></param>
        /// <param name="api"></param>
        /// <returns></returns>
        private HttpRequestMessage CreateRequestMessage(HttpMethod method, string api)
        {
            var httpRequestMessage = new HttpRequestMessage(method, BaseUrl + api);
            foreach (var header in GetHeader(api, method.ToString()))
            {
                httpRequestMessage.Headers.Add(header.Key, header.Value);
            }
            return httpRequestMessage;
        }

        /// <summary>
        /// Head Http
        /// </summary>
        /// <param name="url">The URL.</param>
        /// <exception cref="HttpRequestException"></exception>
        /// <exception cref="ArgumentNullException"></exception>
        /// <exception cref="InvalidOperationException"></exception>
        /// <exception cref="TaskCanceledException"></exception>
        /// <returns>所需要的时间(单位ms)</returns>
        private async Task<int> HeadAsync(string url)
        {
            var message = $"连接测试[proxy:{(proxy != null ? proxy.Address : "null")}]{url}: -> ";
            try
            {
                using var request = new HttpRequestMessage(HttpMethod.Head, url);
                var now = DateTime.Now;
                using var response = await client.SendAsync(request);
                var ms = (DateTime.Now - now).Milliseconds;
                Log.Debug("{Message}{Ms}ms", message, ms);
                return ms;
            }
            catch (Exception exception)
            {
                Log.Error("Get Exception: {Ex}", exception);
                throw;
            }
        }

        /// <summary>
        /// Get Async
        /// </summary>
        /// <typeparam name="T">返回类型</typeparam>
        /// <param name="api">Pica API</param>
        /// <exception cref="PicaComicException"></exception>
        /// <returns></returns>
        private async Task<T> GetAsync<T>(string api) where T : PicaResponse
        {
            try
            {
                using var request = CreateRequestMessage(HttpMethod.Get, api);
                using var response = await client.SendAsync(request);
                var resp = await response.Content.ReadAsStringAsync();
                Log.Debug("\n[Get]{Api}:\nproxy:{Proxy}\nreturn:{Resp}", api,
                    proxy != null ? proxy.Address : "null", resp);
                var res = JsonSerializer.Deserialize<T>(resp);
                if (res.Code != 200)
                {
                    throw new PicaComicException(res);
                }

                return res;
            }
            catch (Exception exception)
            {
                Log.Error("Get Exception: {Ex}", exception);
                throw;
            }
        }

        /// <summary>
        /// Post Async
        /// </summary>
        /// <typeparam name="T">返回类型</typeparam>
        /// <param name="api">Pica API</param>
        /// <param name="payload">传递数据</param>
        /// <exception cref="PicaComicException"></exception> 
        /// <returns></returns>
        private async Task<T> PostAsync<T>(string api, Dictionary<string, string> payload) where T : PicaResponse
        {
            return await PostAsync<T>(api, JsonSerializer.Serialize(payload));
        }

        private async Task<T> PostAsync<T>(string api, Dictionary<string, string> payload,
            JsonSerializerOptions options) where T : PicaResponse
        {
            return await PostAsync<T>(api, JsonSerializer.Serialize(payload, options));
        }

        private async Task<T> PostAsync<T>(string api) where T : PicaResponse
        {
            return await PostAsync<T>(api, JsonSerializer.Serialize(new Dictionary<string, string>()));
        }

        private async Task<T> PostAsync<T>(string api, string data) where T : PicaResponse
        {
            try
            {
                using var request = CreateRequestMessage(HttpMethod.Post, api);
                request.Content = new StringContent(data, Encoding.UTF8, "application/json");
                request.Content.Headers.Remove("Content-Type");
                request.Content.Headers.Add("Content-Type", "application/json; charset=UTF-8");
                using var response = await client.SendAsync(request);
                var resp = await response.Content.ReadAsStringAsync();
                Log.Debug("\n[Post]{Api}:\nproxy:{Proxy}\npayload:{Data}\nreturn:{Resp}", api,
                    proxy != null ? proxy.Address : "null", data, resp);
                var res = JsonSerializer.Deserialize<T>(resp);
                if (res.Code != 200)
                {
                    throw new PicaComicException(res);
                }
                return res;
            }
            catch (Exception exception)
            {
                Log.Error("Get Exception: {Ex}", exception);
                throw;
            }
        }

        /// <summary>
        /// Put Async
        /// </summary>
        /// <typeparam name="T">返回类型</typeparam>
        /// <param name="api">Pica API</param>
        /// <param name="payload">传递数据</param>
        /// <exception cref="PicaComicException"></exception>
        /// <returns></returns>
        private async Task<T> PutAsync<T>(string api, Dictionary<string, string> payload) where T : PicaResponse
        {
            try
            {
                using var request = CreateRequestMessage(HttpMethod.Put, api);
                var data = JsonSerializer.Serialize(payload);
                request.Content = new StringContent(data, Encoding.UTF8, "application/json");
                request.Content.Headers.Remove("Content-Type");
                request.Content.Headers.Add("Content-Type", "application/json; charset=UTF-8");
                using var response = await client.SendAsync(request);
                var resp = await response.Content.ReadAsStringAsync();
                Log.Debug("\n[Put]{Api}:\nproxy:{Proxy}\npayload:{Data}\nreturn:{Resp}", api,
                    proxy != null ? proxy.Address : "null", data, resp);
                var res = JsonSerializer.Deserialize<T>(resp);
                if (res.Code != 200)
                {
                    throw new PicaComicException(res);
                }
                return res;
            }
            catch (Exception exception)
            {
                Log.Error("Get Exception: {Ex}", exception);
                throw;
            }
        }

        #endregion

        /// <summary>
        /// 设置登录凭证
        /// </summary>
        /// <param name="t">登录凭证</param>
        public void SetToken(string t)
        {
            token = t;
        }

        /// <summary>
        /// 是否存在登录凭证
        /// </summary>
        public bool HasToken => !string.IsNullOrEmpty(token);

        /// <summary>
        /// 重置代理
        /// </summary>
        public void ResetProxy()
        {
            client = new HttpClient(handler: new HttpClientHandler());
        }

        /// <summary>
        /// 设置超时时间
        /// </summary>
        public void SetTimeout(double timeout)
        {
            Timeout = timeout;
            client.Timeout = TimeSpan.FromSeconds(timeout);
        }

        /// <summary>
        /// 设置代理,仅支持'http', 'socks4', 'socks4a', 'socks5'
        /// </summary>
        /// <param name="p">Proxy Address</param>
        public void SetProxy(Uri p)
        {
            proxy = new WebProxy
            {
                Address = p,
                BypassProxyOnLocal = false,
                UseDefaultCredentials = false,
            };
            var innerHandler = new HttpClientHandler
            {
                Proxy = proxy,
                UseProxy = true
            };
            client = new HttpClient(innerHandler);
            SetTimeout(Timeout);
        }

        /// <summary>
        /// 连接测试
        /// </summary>
        /// <returns>所需要的时间(单位ms)</returns>
        public async Task<int> PingBaseUrl()
        {
            return await HeadAsync(BaseUrl);
        }

        /// <summary>
        /// 连接测试
        /// </summary>
        /// <param name="url">The URL.</param>
        /// <returns>所需要的时间(单位ms)</returns>
        public async Task<int> Ping(string url)
        {
            return await HeadAsync(url);
        }

        /// <summary>
        /// 登录接口
        /// </summary>
        /// <param name="email"></param>
        /// <param name="password"></param>
        /// <exception cref="PicaComicException"></exception> 
        /// <returns></returns>
        public async Task<SignInResponse> SignIn(string email, string password)
        {
            var res = await PostAsync<SignInResponse>("auth/sign-in",
                new Dictionary<string, string>
                {
                    { "email", email },
                    { "password", password }
                });
            if (res.Data != null)
            {
                token = res.Data.Token;
            }

            return res;
        }

        /// <summary>
        /// 获取用户资料接口
        /// </summary>
        /// <param name="id"></param>
        /// <exception cref="PicaComicException"></exception> 
        /// <returns></returns>
        public async Task<ProfileResponse> Profile(string id = null)
        {
            return await GetAsync<ProfileResponse>($"users/{(id is null ? "" : id + "/")}profile");
        }

        /// <summary>
        /// 大家都在搜 接口
        /// </summary>
        /// <returns></returns>
        public async Task<KeywordsResponse> Keywords()
        {
            return await GetAsync<KeywordsResponse>("keywords");
        }

        /// <summary>
        /// 看过这篇的也看 接口
        /// </summary>
        /// <param name="comicId">The book identifier.</param>
        /// <returns></returns>
        public async Task<ComicRandomResponse> Recommendation(string comicId)
        {
            return await GetAsync<ComicRandomResponse>($"comics/{comicId}/recommendation");
        }

        /// <summary>
        /// 获取所有分区 接口
        /// </summary>
        public async Task<CategoriesResponse> Categories()
        {
            return await GetAsync<CategoriesResponse>("categories");
        }

        /// <summary>
        /// 获取分区内漫画 接口
        /// </summary>
        /// <param name="category">分区名称<see cref="Category.Title"/></param>
        /// <param name="page">第几页</param>
        /// <param name="s">default: <see cref="SortRule.dd"/></param>
        public async Task<CategoryResponse> Category(string category, int page = 1, SortRule s = SortRule.dd)
        {
            if (category == "最近更新") category = "";
            var c = string.IsNullOrEmpty(category) ? "" : $"&c={HttpUtility.UrlEncode(category)}";
            return await GetAsync<CategoryResponse>($"comics?page={page}&s={s}" + c);
        }

        /// <summary>
        /// 随机本子接口
        /// </summary>
        public async Task<ComicRandomResponse> ComicRandom()
        {
            return await GetAsync<ComicRandomResponse>($"comics/random");
        }

        /// <summary>
        /// 神魔推荐
        /// </summary>
        /// <returns></returns>
        public async Task<CollectionsResponse> ComicCollections()
        {
            return await GetAsync<CollectionsResponse>($"collections");
        }

        /// <summary>
        /// 获取漫画详细信息 接口
        /// </summary> 
        /// <param name="comicId">漫画ID<see cref="Comic.Id"/></param>
        /// <returns></returns>
        public async Task<ComicInfoResponse> ComicInfo(string comicId)
        {
            return await GetAsync<ComicInfoResponse>($"comics/{comicId}");
        }

        /// <summary>
        /// 获取话 接口
        /// </summary> 
        /// <param name="comicId">漫画ID<see cref="Comic.Id"/></param>
        /// <param name="page">第几页</param>
        /// <returns></returns>
        public async Task<EpisodeResponse> Episodes(string comicId, int page)
        {
            return await GetAsync<EpisodeResponse>($"comics/{comicId}/eps?page={page}");
        }

        /// <summary>
        /// 获取图片合集 接口
        /// </summary>
        /// <param name="comicId">漫画ID<see cref="Comic.Id"/></param>
        /// <param name="epsId">话Order<see cref="Episode.Order"/></param>
        /// <param name="page">第几页</param>
        /// <returns></returns>
        public async Task<PictureResponse> Pictures(string comicId, int epsId, int page)
        {
            return await GetAsync<PictureResponse>($"comics/{comicId}/order/{epsId}/pages?page={page}");
        }

        /// <summary>
        /// 获得漫画评论 接口
        /// </summary>
        /// <param name="comicId">漫画ID</param>
        /// <param name="page">第几页</param>
        /// <returns></returns>
        public async Task<CommentResponse> ComicComments(string comicId, int page)
        {
            return await GetAsync<CommentResponse>($"comics/{comicId}/comments?page={page}");
        }

        /// <summary>
        /// 获得自己的评论 接口
        /// </summary>
        /// <param name="page">第几页</param>
        /// <returns></returns>
        public async Task<CommentResponse> ProfileComments(int page)
        {
            return await GetAsync<CommentResponse>($"users/my-comments?page={page}");
        }

        /// <summary>
        /// 修改密码 接口
        /// </summary>
        /// <param name="newPassword">新密码</param>
        /// <param name="oldPassword">旧密码</param>
        /// <returns></returns>
        public async Task<PicaResponse> ChangePassword(string newPassword, string oldPassword)
        {
            return await PutAsync<PicaResponse>("users/password", new Dictionary<string, string>
            {
                { "new_password", newPassword },
                { "old_password", oldPassword },
            });
        }

        /// <summary>
        /// 修改头像 接口
        /// </summary>
        /// <param name="imgData">base64图片</param>
        /// <returns></returns>
        public async Task<PicaResponse> SetAvatar(string imgData)
        {
            return await PutAsync<PicaResponse>("users/avatar", new Dictionary<string, string>
            {
                { "avatar", imgData }
            });
        }

        /// <summary>
        /// 修改头像 接口
        /// </summary>
        /// <param name="img">图片</param>
        /// <returns></returns>
        public async Task<PicaResponse> SetAvatar(StorageFile img)
        {
            var stream = await img.OpenStreamForReadAsync();
            var bytes = new byte[(int)stream.Length];
            stream.Read(bytes, 0, (int)stream.Length);
            var imgData = "data:image/" + img.FileType.Remove(0, 1) + ";base64," + Convert.ToBase64String(bytes);
            return await SetAvatar(imgData);
        }

        /// <summary>
        /// 签到 接口
        /// </summary>
        /// <returns></returns>
        public async Task<PunchInResponse> PunchIn()
        {
            return await PostAsync<PunchInResponse>("users/punch-in");
        }

        /// <summary>
        /// 个人收藏 接口
        /// </summary>
        /// <param name="page">第几页</param>
        /// <param name="s">排序<see cref="SortRule"/></param>
        /// <returns></returns>
        public async Task<CategoryResponse> ProfileFavourites(int page, SortRule s = SortRule.dd)
        {
            return await GetAsync<CategoryResponse>($"users/favourite?s={s}&page={page}");
        }

        /// <summary>
        /// 把漫画添加到个人收藏 接口
        /// </summary>
        /// <param name="comicId">漫画ID</param>
        /// <returns></returns>
        public async Task<ActionResponse> ComicFavourite(string comicId)
        {
            return await PostAsync<ActionResponse>($"comics/{comicId}/favourite");
        }

        /// <summary>
        /// 给漫画加爱心 接口
        /// </summary>
        /// <param name="comicId">漫画ID</param>
        /// <returns></returns>
        public async Task<ActionResponse> ComicLike(string comicId)
        {
            return await PostAsync<ActionResponse>($"comics/{comicId}/like");
        }

        /// <summary>
        /// 高级搜索 接口
        /// </summary>
        /// <param name="categories">分区</param>
        /// <param name="keyword">关键词</param>
        /// <param name="page">第几页</param>
        /// <param name="s">排序<see cref="SortRule"/></param>
        /// <returns></returns>
        public async Task<SearchResultResponse> AdvancedSearch(string keyword, int page,
            SortRule s = SortRule.dd, List<string> categories = null)
        {
            var data = new SearchData
            {
                Sort = s.ToString(),
                Keyword = keyword,
                Categories = categories,
            };
            var options = new JsonSerializerOptions()
            {
                DefaultIgnoreCondition = JsonIgnoreCondition.WhenWritingNull,
                Encoder = System.Text.Encodings.Web.JavaScriptEncoder.UnsafeRelaxedJsonEscaping,
            };
            return await PostAsync<SearchResultResponse>($"comics/advanced-search?page={page}",
                JsonSerializer.Serialize(data, options));
        }

        /// <summary>
        /// 获取评论的评论 接口
        /// </summary>
        /// <param name="commentId">评论ID</param>
        /// <param name="page">第几页</param>
        /// <returns></returns>
        public async Task<CommentResponse> CommentChildren(string commentId, int page)
        {
            return await GetAsync<CommentResponse>($"comments/{commentId}/childrens?page={page}");
        }

        /// <summary>
        /// 喜欢一个评论 接口
        /// </summary>
        /// <param name="commentId">评论ID</param>
        /// <returns></returns>
        public async Task<ActionResponse> CommentLike(string commentId)
        {
            return await PostAsync<ActionResponse>($"comments/{commentId}/like");
        }

        /// <summary>
        /// 发送漫画评论 接口
        /// </summary>
        /// <param name="comicId">漫画ID</param>
        /// <param name="message">评论</param>
        /// <returns></returns>
        public async Task<PicaResponse> SendComicComment(string comicId, string message)
        {
            return await PostAsync<PicaResponse>($"comics/{comicId}/comments",
                new Dictionary<string, string>
                {
                    { "content", message },
                }, new JsonSerializerOptions()
                {
                    Encoder = System.Text.Encodings.Web.JavaScriptEncoder.UnsafeRelaxedJsonEscaping,
                });
        }

        /// <summary>
        /// 发送子评论 接口
        /// </summary>
        /// <param name="commentId">评论ID</param>
        /// <param name="message">评论</param>
        /// <returns></returns>
        public async Task<PicaResponse> SendCommentChildren(string commentId, string message)
        {
            return await PostAsync<PicaResponse>($"comments/{commentId}",
                new Dictionary<string, string>
                {
                    { "content", message },
                },
                new JsonSerializerOptions()
                {
                    Encoder = System.Text.Encodings.Web.JavaScriptEncoder.UnsafeRelaxedJsonEscaping,
                });
        }

        /// <summary>
        /// 骑士榜
        /// </summary>
        /// <returns></returns>
        public async Task<KnightsResponse> KnightLeaderboard()
        {
            return await GetAsync<KnightsResponse>("comics/knight-leaderboard");
        }

        /// <summary>
        /// 排行榜
        /// </summary>
        /// <param name="tt"><see cref="LeaderboardTime"/>时间区间</param>
        /// <returns></returns>
        public async Task<LeaderBoardResponse> Leaderboard(LeaderboardTime tt = LeaderboardTime.H24)
        {
            return await GetAsync<LeaderBoardResponse>($"comics/leaderboard?tt={tt}&ct=VC");
        }
    }
}