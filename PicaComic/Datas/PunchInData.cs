namespace PicaComic.Datas
{
    public class PunchInData
    {
        [JsonPropertyName("res")]
        public PunchInRes Res { get; set; }
    }
    public class PunchInRes
    {
        [JsonPropertyName("status")]
        public string Status { get; set; }
        [JsonPropertyName("punchInLastDay")]
        public string PunchInLastDay { get; set; }
    }
}
