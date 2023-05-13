using BikaSharpAPI.DataModels;
using Windows.System;

namespace PicaComic
{
    /// <summary>
    /// 哔咔漫画Http客户端
    /// </summary>
    public static class PicaClient
    {
        #region Fields
        /// <summary>
        /// HttpClient实例
        /// </summary>
        private static HttpClient _client = new HttpClient(new HttpClientHandler());

        /// <summary>
        /// 端口
        /// </summary>
        private static WebProxy _proxy;

        /// <summary>
        /// 登录凭证
        /// </summary>
        private static string _token = null;

        /// <summary>
        /// 分流
        /// </summary>
        public static int AppChannel = 3;
        /// <summary>
        /// 图片分流
        /// </summary>
        public static int FileChannel = 3;

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
        private static string _nonce = Guid.NewGuid().ToString().Replace("-", string.Empty);
        #endregion
        #region Private Http
        /// <summary>
        /// 设置哔咔请求Header
        /// </summary>
        /// <param name="api">api name</param>
        /// <param name="method">http method</param>
        /// <returns></returns>
        private static Dictionary<string, string> GetHeader(string api, string method)
        {
            string t = DateTimeOffset.Now.ToUnixTimeSeconds().ToString();
            Dictionary<string, string> header = new Dictionary<string, string>
            {
                { "image-quality", "original" },
                { "api-key", ApiKey },
                { "accept", "application/vnd.picacomic.com.v1+json" },
                { "app-channel", AppChannel.ToString() },
                { "time", t },
                { "app-version", AppVersion },
                { "nonce", _nonce },
                { "app-uuid", "defaultUuid" },
                { "app-platform", "android" },
                { "app-build-version", "45" },
                { "User-Agent", "okhttp/3.8.1" },
                { "signature", HmacSHA256(api + t + _nonce + method + ApiKey, SignKey) },
            };
            if (_token != null)
            {
                header.Add("authorization", _token);
            }

            return header;
        }

        /// <summary>
        /// HmacSHA256 加密
        /// </summary>
        /// <param name="secret">text need to encrypt</param>
        /// <param name="signKey">signKey</param>
        /// <returns>hex ciphertext</returns>
        private static string HmacSHA256(string secret, string signKey)
        {
            string signRet = string.Empty;
            using (HMACSHA256 mac = new HMACSHA256(Encoding.UTF8.GetBytes(signKey)))
            {
                byte[] hash = mac.ComputeHash(Encoding.UTF8.GetBytes(secret.ToLower()));
                signRet = System.Convert.ToHexString(hash).ToLower();
            }

            return signRet;
        }

        /// <summary>
        /// 创建HttpRequestMessage
        /// </summary>
        /// <param name="method"></param>
        /// <param name="api"></param>
        /// <returns></returns>
        private static HttpRequestMessage CreateRequestMessage(HttpMethod method, string api)
        {
            HttpRequestMessage httpRequestMessage = new HttpRequestMessage(method, BaseUrl + api);

            foreach (KeyValuePair<string, string> header in GetHeader(api, method.ToString()))
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
        private static async Task<int> HeadAsync(string url)
        {
            string message = $"连接测试[proxy:{(_proxy != null ? _proxy.Address : "null")}]{url}: -> ";
            try
            {
                using (HttpRequestMessage request = new HttpRequestMessage(HttpMethod.Head, url))
                {
                    DateTime now = DateTime.Now;
                    using (HttpResponseMessage response = await _client.SendAsync(request))
                    {
                        int ms = (DateTime.Now - now).Milliseconds;
                        Log.Information("{Message}{Ms}ms", message, ms);
                        return ms;
                    }
                }
            }
            catch (HttpRequestException ex)
            {
                Log.Error("{Message} time out", message, ex);
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
        private static async Task<T> GetAsync<T>(string api) where T : PicaResponse
        {
            try
            {
                using (var request = CreateRequestMessage(HttpMethod.Get, api))
                {
                    using (var response = await _client.SendAsync(request))
                    {
                        string resp = await response.Content.ReadAsStringAsync();
                        Log.Information("\n[Get]{Api}:\nproxy:{Proxy}\nreturn:{Resp}", api, _proxy != null ? _proxy.Address : "null",  resp);
                        T res = resp.ToObj<T>();
                        if (res.Code != 200)
                        {
                            throw new PicaComicException(res);
                        }
                        return res;
                    }
                }
            }
            catch (HttpRequestException ex)
            {
                Log.Error("  ", ex);
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
        private static async Task<T> PostAsync<T>(string api, Dictionary<string, string> payload) where T : PicaResponse
        {
            using (var request = CreateRequestMessage(HttpMethod.Post, api))
            {
                string data = payload.ToJson();
                request.Content = new StringContent(data, Encoding.UTF8, "application/json");
                request.Content.Headers.Remove("Content-Type");
                request.Content.Headers.Add("Content-Type", "application/json; charset=UTF-8");
                using (var response = await _client.SendAsync(request))
                {
                    string resp = await response.Content.ReadAsStringAsync();
                    Log.Information("\n[Post]{Api}:\nproxy:{Proxy}\npayload:{data}\nreturn:{Resp}", api, _proxy != null ? _proxy.Address : "null",  data, resp);
                    T res = resp.ToObj<T>();
                    if (res.Code != 200)
                    {
                        throw new PicaComicException(res);
                    }
                    return res;
                }
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
        private static async Task<T> PutAsync<T>(string api, Dictionary<string, string> payload)  where T : PicaResponse
        {
            using (var request = CreateRequestMessage(HttpMethod.Put, api))
            {
                string data = payload.ToJson(); 
                request.Content = new StringContent(data, Encoding.UTF8, "application/json");
                request.Content.Headers.Remove("Content-Type");
                request.Content.Headers.Add("Content-Type", "application/json; charset=UTF-8");
                using (var response = await _client.SendAsync(request))
                {
                    string resp = await response.Content.ReadAsStringAsync();
                    Log.Information("\n[Put]{Api}:\nproxy:{Proxy}\npayload:{data}\nreturn:{Resp}", api, _proxy != null ? _proxy.Address : "null", data, resp);
                    T res = resp.ToObj<T>();
                    if(res.Code != 200)
                    {
                        throw new PicaComicException(res);
                    }
                    return res;
                }
            }

        }
        #endregion
        /// <summary>
        /// 重置代理
        /// </summary>
        public static void ResetProxy()
        {
            _client = new HttpClient(handler: new HttpClientHandler());
        }

        /// <summary>
        /// 设置代理
        /// </summary>
        /// <param name="proxy">Proxy Address</param>
        public static void SetProxy(Uri proxy)
        {
            _proxy = new WebProxy
            {
                Address = proxy,
                BypassProxyOnLocal = false,
                UseDefaultCredentials = false,
            };
            HttpClientHandler innerHandler = new HttpClientHandler
            {
                Proxy = _proxy,
                UseProxy = true
            };
            _client = new HttpClient(innerHandler);
        }
        /// <summary>
        /// 连接测试
        /// </summary>
        /// <returns>所需要的时间(单位ms)</returns>
        public static async Task<int> PingBaseUrl()
        {
            return await HeadAsync(BaseUrl);
        }

        /// <summary>
        /// 连接测试
        /// </summary>
        /// <param name="url">The URL.</param>
        /// <returns>所需要的时间(单位ms)</returns>
        public static async Task<int> Ping(string url)
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
        public static async Task<SignInResponse> SignIn(string email, string password)
        {
            SignInResponse res = await PostAsync<SignInResponse>("auth/sign-in",
                new Dictionary<string, string>
                {
                    { "email", email },
                    { "password", password }
                });
            if (res.Data != null)
            {
                _token = res.Data.Token;
            }
            return res;
        }
        /// <summary>
        /// 获取用户资料接口
        /// </summary>
        /// <param name="id"></param>
        /// <exception cref="PicaComicException"></exception> 
        /// <returns></returns>
        public static async Task<ProfileResponse> Profile(string id = null)
        {
            ProfileResponse res = await GetAsync<ProfileResponse>($"users/{(id is null ? "" : id + "/")}profile");
            return res;
        }
        /// <summary>
        /// 大家都在搜 接口
        /// </summary>
        /// <returns></returns>
        public static async Task<KeywordsResponse> Keywords()
        {
            KeywordsResponse res = await GetAsync<KeywordsResponse>("keywords");
            return res;
        }
        /// <summary>
        /// 看过这篇的也看 接口
        /// </summary>
        /// <param name="bookId">The book identifier.</param>
        /// <returns></returns>
        public static async Task<CategoryResponse> Recommendation(string bookId)
        {
            CategoryResponse res = await GetAsync<CategoryResponse>($"comics/{bookId}/recommendation");
            return res;
        }
        /// <summary>
        /// 获取所有分区接口
        /// </summary>
        /// <returns></returns>
        public static async Task<CategoriesResponse> Categories()
        {
            CategoriesResponse res = await GetAsync<CategoriesResponse>("categories");
            return res;
        }
        /// <summary>
        /// 获取分区内漫画接口
        /// </summary>
        /// <param name="page">第几页</param>
        /// <param name="c">分区名称<see cref="Category.Title"/></param>
        /// <param name="s">default: <see cref="SortRule.dd"/></param>
        /// <returns><see cref="ComicsPage"/></returns>
        public static async Task<CategoryResponse> Category(int page, string c, SortRule s = SortRule.dd)
        {

            CategoryResponse res = await GetAsync<CategoryResponse>($"comics?page={page}&c={HttpUtility.UrlEncode(c)}&s={s}");
            return res;
        }
        /// <summary>
        /// 获取漫画详细信息接口
        /// </summary> 
        /// <param name="bookId">漫画ID<see cref="Comic.Id"/></param>
        /// <returns></returns>
        public static async Task<ComicInfoResponse> ComicInfo(string bookId)
        {

            ComicInfoResponse res = await GetAsync<ComicInfoResponse>($"comics/{bookId}");
            return res;
        }
        /// <summary>
        /// 获取话接口
        /// </summary> 
        /// <param name="bookId">漫画ID<see cref="Comic.Id"/></param>
        /// <param name="page">第几页</param>
        /// <returns></returns>
        public static async Task<EpisodeResponse> Episodes(string bookId, int page)
        {

            EpisodeResponse res = await GetAsync<EpisodeResponse>($"comics/{bookId}/eps?page={page}");
            return res;
        }

        /// <summary>
        /// 获取图片合集接口
        /// </summary>
        /// <param name="bookId">漫画ID<see cref="Comic.Id"/></param>
        /// <param name="epsId">话Order<see cref="Episode.Order"/></param>
        /// <param name="page">第几页</param>
        /// <returns></returns>
        public static async Task<PictureResponse> Pictures(string bookId, int epsId, int page)
        {

            PictureResponse res = await GetAsync<PictureResponse>($"comics/{bookId}/order/{epsId}/pages?page={page}");
            return res;
        }
    }
}