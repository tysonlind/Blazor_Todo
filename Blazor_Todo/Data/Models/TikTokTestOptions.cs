using Microsoft.Extensions.Options;

namespace Blazor_Todo.Data.Models
{
    public class TikTokTestOptions : IOptions<TikTokApiOptions>
    {
        public TikTokApiOptions Value { get; set; }
    }
}
