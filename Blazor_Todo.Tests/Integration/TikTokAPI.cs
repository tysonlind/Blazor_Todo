using Xunit;
using System.IO;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Options;
using System.Threading.Tasks;
using Blazor_Todo.Data.Services;
using Blazor_Todo.Data.Handlers;
using Blazor_Todo.Data.Models;
using RestSharp;

namespace Blazor_Todo.Tests.HandlerTests
{
    public class HandlerTests
    {
        private readonly TikTokApiOptions _apiOptions;

        public HandlerTests()
        {
            // Load configuration from the appsettings.json in your Blazor_Todo project
            var config = new ConfigurationBuilder()
                .SetBasePath(AppContext.BaseDirectory) // The current directory of the test project
                .AddJsonFile("appsettings.json")
                // Adjust the path based on folder structure
                .Build();
            Console.WriteLine(Directory.GetCurrentDirectory());
            // Bind the TikTokApiOptions section from appsettings.json
            _apiOptions = config.GetSection("TikTokApi").Get<TikTokApiOptions>();
        }

        [Fact]
        public async Task TestTikTokAPI_ActualResponse_ReturnsNonNullAwemeItems()
        {
            // Arrange
            var options = new TikTokTestOptions(); // Wrap the options in IOptions<T>
            options.Value = _apiOptions;
            var apiHandler = new TikTokAPIHandler(options); // Pass in options to the handler
            var apiService = new TikTokRecommendedDataService(apiHandler); // Instantiate the service with the handler

            // Act
            var result = await apiService.GetTikTokRecommendationsAsync();

            // Assert
            Assert.NotNull(result); // Ensure the result is not null
            Assert.NotNull(result.AwemeList); // Ensure AwemeList is not null
            Assert.NotEmpty(result.AwemeList); // Ensure the AwemeList contains items

            // Loop through the aweme items and check if they have non-null values
            foreach (var awemeItem in result.AwemeList)
            {
                Assert.NotNull(awemeItem.AwemeId);      // AwemeId should not be null
                Assert.NotNull(awemeItem.Description);  // Description should not be null
                Assert.NotNull(awemeItem.ShareUrl);     // ShareUrl should not be null
                Assert.NotNull(awemeItem.Statistics);   // Statistics should not be null
                Assert.NotNull(awemeItem.Statistics.AwemeId); // AwemeId in statistics should not be null
            }
        }
    }
}
