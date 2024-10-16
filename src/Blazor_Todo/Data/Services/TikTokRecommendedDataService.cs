using Blazor_Todo.Data.Handlers;
using Blazor_Todo.Data.Models;
using System.Text.Json;

namespace Blazor_Todo.Data.Services
{
    public class TikTokRecommendedDataService
    {
        private readonly TikTokAPIHandler _apiHandler;

        public TikTokRecommendedDataService(TikTokAPIHandler apiHandler)
        {
            _apiHandler = apiHandler;
        }

        public async Task<TikTokRecommendedData?> GetTikTokRecommendationsAsync()
        {
            // Use the generic method to fetch TikTokRecommendedData
            return await _apiHandler.GetRecommendedListAsync<TikTokRecommendedData>();
        }
    }

}
