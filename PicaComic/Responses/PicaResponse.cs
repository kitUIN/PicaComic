namespace PicaComic.Responses
{
    public class PicaResponse
    {
        /// <summary>
        /// Code
        /// </summary>
        [JsonPropertyName("code")]
        public int Code { get; set; }

        /// <summary>
        /// Message
        /// </summary>
        [JsonPropertyName("message")]
        public string Message { get; set; }

        /// <summary>
        /// Error
        /// </summary>
        [JsonPropertyName("error")]
        public string Error { get; set; }

        /// <summary>
        /// Error Detail
        /// </summary>
        [JsonPropertyName("detail")]
        public string Detail { get; set; }
    }
}

