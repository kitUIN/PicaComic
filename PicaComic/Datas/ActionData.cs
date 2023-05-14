namespace PicaComic.Datas
{
    public class ActionData
    {
        /// <value>
        /// unlike<br />like<br />un_favourite<br />favourite 
        /// </value>
        [JsonPropertyName("action")]
        public string action { get; set; }
    }
}
