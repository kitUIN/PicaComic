namespace PicaComic.Exceptions
{
    public class PicaComicException: Exception
    {
        public int PicaCode { get; set; }
        public string PicaError { get; set; }
        public string PicaMessage { get; set; }
        public string ChineseMessage { get; set; }
        public string Detail { get; set; }
        public PicaComicException(string message) : base(message)
        {
            
        }
        public PicaComicException(int picaCode, string picaError, string detail)
        {
            PicaCode = picaCode;
            Detail = detail;
            PicaError = picaError;
            ChineseMessage = PicaMessage;
            GetChinese();
        }
        public PicaComicException(string message, int picaCode, string picaError, string detail)
        {
            PicaMessage = message;
            PicaCode = picaCode;
            Detail = detail;
            PicaError = picaError;
            ChineseMessage = PicaMessage;
            GetChinese();
        }
        public PicaComicException(PicaResponse response)
        {
            PicaMessage = response.Message;
            PicaCode = response.Code;
            Detail = response.Detail;
            PicaError = response.Error;
            ChineseMessage = PicaMessage;
            GetChinese();
        }
        private void GetChinese()
        {
            switch (PicaCode)
            {
                case 400:
                    switch (PicaError)
                    {
                        case "1019":
                            ChineseMessage = "你不能评论.";
                            break;
                        case "1031":
                            ChineseMessage = "你的等级不够,无法评论.";
                            break;
                        case "1004":
                            ChineseMessage = "账号或密码错误.";
                            break;
                        case "1008":
                            ChineseMessage = "账号已存在,请重新输入.";
                            break;
                        case "1009":
                            ChineseMessage = "用户名已存在,请重新输入.";
                            break;
                        case "1014":
                            ChineseMessage = "漫画正在审核.";
                            break;
                    }
                    break;
                case 401:
                    if (PicaError == "1005")
                    {
                        ChineseMessage = "登录凭证失效,请重新登录.";
                    }
                    break;
                case 404:
                    if (PicaError == "1007")
                    {
                        ChineseMessage = "404 NOT FOUND!";
                    }
                    break;
                default:
                    ChineseMessage = PicaMessage;
                    break;
            }
        }
    }
}
