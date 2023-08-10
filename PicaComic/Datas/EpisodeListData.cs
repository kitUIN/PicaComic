namespace PicaComic.Datas;

/// <summary>
/// $.data
/// </summary>
public class EpisodeListData
{
    /// <summary>
    /// $.data.eps
    /// </summary>
    [JsonPropertyName("eps")]
    public EpisodeList Episodes { get; set; }
}