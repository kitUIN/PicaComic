namespace PicaComic.Datas
{
    public class CommentsData
    {
        [JsonPropertyName("comments")]
        public CommentList Comments { get; set; }

        [JsonPropertyName("topComments")]
        public List<Comment> TopComments { get; set; }
    }
}
