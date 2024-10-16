namespace Blazor_Todo.Data.Handlers
{
    using Blazor_Todo.Data.Models;
    using RestSharp;
    using System.Text.Json;
    using System.Threading.Tasks;
    using Microsoft.Extensions.Options;

    public class TikTokAPIHandler
    {
        private readonly RestClient _client;
        private readonly TikTokApiOptions _apiSettings;

        public TikTokAPIHandler(IOptions<TikTokApiOptions> apiSettings)
        {
            _client = new RestClient(apiSettings.Value.BaseUrl);
            _apiSettings = apiSettings.Value;
        }

        public async Task<T?> GetRecommendedListAsync<T>()
        {
            var request = new RestRequest();
            request.Method = Method.Get;
            request.AddHeader("x-rapidapi-key", _apiSettings.ApiKey);
            request.AddHeader("x-rapidapi-host", _apiSettings.ApiHost);

            // Make the asynchronous request  
            var response = _client.Execute(request);

            // Check if the response was successful  
            if (response.IsSuccessful)
            {
                // Deserialize the response content to type T
                return JsonSerializer.Deserialize<T>(response.Content); // For System.Text.Json

                // If you're using Newtonsoft.Json, you can replace the line above with:
                // return JsonConvert.DeserializeObject<T>(response.Content);
            }

            // Log or handle the error  
            Console.WriteLine($"Error: {response.StatusCode} - {response.ErrorMessage}");
            return default;
        }
    }


}

