using System.Net.NetworkInformation;
using System.Text.Json.Serialization;


namespace Blazor_Todo.Data.Models
{
    public class TikTokRecommendedData
    {
        [JsonPropertyName("aweme_list")]
        public List<AwemeItem> AwemeList { get; set; } = new List<AwemeItem>();
    }

    public class AwemeItem
    {
        [JsonPropertyName("aweme_id")]
        public string? AwemeId { get; set; }

        [JsonPropertyName("desc")]
        public string? Description { get; set; }

        [JsonPropertyName("statistics")]
        public Statistics? Statistics { get; set; }

        [JsonPropertyName("share_url")]
        public string? ShareUrl { get; set; }

    }

    public class Statistics
    {
        [JsonPropertyName("aweme_id")]
        public string? AwemeId { get; set; }

        [JsonPropertyName("comment_count")]
        public int CommentCount { get; set; }

        [JsonPropertyName("play_count")]
        public int PlayCount { get; set; }

    }
}
