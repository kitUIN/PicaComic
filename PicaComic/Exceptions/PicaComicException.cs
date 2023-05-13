namespace PicaComic.Exceptions
{
    public class PicaComicException: Exception
    {
        public int PicaCode { get; set; }
        public string PicaError { get; set; }
        public string PicaMessage { get; set; }
        public string Detail { get; set; }
        public PicaComicException(string message) : base(message)
        {
            
        }
        public PicaComicException(int picaCode, string picaError, string detail)
        {
            PicaCode = picaCode;
            Detail = detail;
            PicaError = picaError;
        }
        public PicaComicException(string message, int picaCode, string picaError, string detail)
        {
            PicaMessage = message;
            PicaCode = picaCode;
            Detail = detail;
            PicaError = picaError;
        }
        public PicaComicException(PicaResponse response)
        {
            PicaMessage = response.Message;
            PicaCode = response.Code;
            Detail = response.Detail;
            PicaError = response.Error;
        }
    }
}
