namespace PicaComic.Responses
{
    /// <summary>
    /// 一些动作的返回:<br/>
    /// 漫画喜欢<see cref="PicaClient.ComicLike(string)"/><br/>
    /// 漫画收藏<see cref="PicaClient.ComicFavourite(string)"/><br/>
    /// 评论喜欢<see cref="PicaClient.CommentLike(string)"/><br/>
    /// </summary>
    /// <seealso cref="PicaComic.Responses.PicaResponse" />
    public class ActionResponse: PicaResponse
    {
        [JsonPropertyName("data")]
        public ActionData Data { get; set; }
    }
}
