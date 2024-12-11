
using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;
using CA2WFVoidWeatherSystems.Models;

namespace CA2WFVoidWeatherSystems.Services
{
    public class TwitterService
    {
        private readonly HttpClient _httpClient;
        private readonly string _bearerToken;

        public TwitterService(HttpClient httpClient, IConfiguration configuration)
        {
            _httpClient = httpClient;
            _bearerToken = configuration["TwitterAPI:BearerToken"]; // Retrieve the token from config
            _httpClient.DefaultRequestHeaders.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue("Bearer", _bearerToken);
        }

        public async Task<string[]> GetWeatherTweetsAsync(string location)
        {
            // Ensure location is URL encoded to handle special characters
            string query = Uri.EscapeDataString($"weather {location}");

            string endpoint = $"https://api.twitter.com/2/tweets/search/recent?query={query}&sort_order=recency&max_results=10";

            try
            {
                // Perform the request
                var response = await _httpClient.GetFromJsonAsync<TwitterResponse>(endpoint);

                if (response == null || response.data == null)
                {
                    throw new Exception("No tweets found or failed to retrieve.");
                }

                var tweets = response?.data?.Select(tweet => tweet.Text).ToArray() ?? new string[0];
                return tweets;
            }
            catch (HttpRequestException ex)
            {
                Console.WriteLine($"HTTP Error: {ex.Message}");
                throw;
            }
        }
    }

}
