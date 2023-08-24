using Client.Interfaces;
using Client.ViewModels;
using Microsoft.AspNetCore.Mvc;
using System.Net.Http;
using System.Text.Json;

namespace Client.Services
{
    public class ApiService : IApiService
    {
        private readonly HttpClient _httpClient;
        private readonly string _apiBaseUrl;

        public ApiService(string apiBaseUrl)
        {
            _httpClient = new HttpClient();
            _apiBaseUrl = apiBaseUrl;
        }
        public Task<WatchViewModel> CreateWatchAsync(CreateViewModel model)
        {
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<WatchViewModel>> GetWatchListAsync()
        {
            string endpoint = $"{_apiBaseUrl}/Watches";

            HttpResponseMessage response = await _httpClient.GetAsync(endpoint);

            if (response.IsSuccessStatusCode)
            {
                string responseContent = await response.Content.ReadAsStringAsync();
                var watches = JsonSerializer.Deserialize<IEnumerable<WatchViewModel>>(responseContent,
                new JsonSerializerOptions { PropertyNameCaseInsensitive = true });
                return watches;
            }
            else
            {
                throw new HttpRequestException($"API call failed with status code: {response.StatusCode}");
            }
        }
    }
}
