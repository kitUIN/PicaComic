﻿namespace PicaComic.Models
{
    public class ComicInfo: Comic
    {
        [JsonPropertyName("_creator")]
        public Profile Creator { get; set; }

        [JsonPropertyName("description")]
        public string Description { get; set; }

        [JsonPropertyName("chineseTeam")]
        public string ChineseTeam { get; set; }

        [JsonPropertyName("tags")]
        public List<string> Tags { get; set; }

        [JsonPropertyName("updated_at")]
        public DateTime UpdatedAt { get; set; }

        [JsonPropertyName("created_at")]
        public DateTime CreatedAt { get; set; }

        [JsonPropertyName("allowDownload")]
        public bool AllowDownload { get; set; }

        [JsonPropertyName("allowComment")]
        public bool AllowComment { get; set; }

        [JsonPropertyName("totalComments")]
        public int TotalComments { get; set; }

        [JsonPropertyName("viewsCount")]
        public int ViewsCount { get; set; }

        [JsonPropertyName("commentsCount")]
        public int CommentsCount { get; set; }

        [JsonPropertyName("isFavourite")]
        public bool IsFavourite { get; set; }

        [JsonPropertyName("isLiked")]
        public bool IsLiked { get; set; }
    }


















}