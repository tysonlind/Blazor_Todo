﻿using Microsoft.Extensions.Options;

namespace Blazor_Todo.Data.Models
{
    public class TikTokApiOptions
    {
        public string ApiKey { get; set; }
        public string ApiHost { get; set; }
        public string BaseUrl { get; set; }
    }
}
