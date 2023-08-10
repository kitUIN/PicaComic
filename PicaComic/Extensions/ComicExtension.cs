namespace PicaComic.Extensions
{
    /// <summary>
    /// 一些帮助方法
    /// </summary>
    public static class ComicExtension
    {
        /// <summary>
        /// 空格隔开的List->String
        /// </summary>
        public static string ListString(this List<string> s)
        {
            s ??= new List<string>();
            return string.Join(" ", s);
        }
    }
}
