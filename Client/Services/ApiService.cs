using AutoMapper;
using Client.DTO;
using Client.Interfaces;
using Client.ViewModels;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Reflection;
using System.Text;
using System.Text.Json;

namespace Client.Services
{
    public class ApiService : IApiService
    {
        private readonly HttpClient _httpClient;
        private readonly string _apiBaseUrl;
        private readonly IMapper _mapper;

        public ApiService(string apiBaseUrl, IMapper mapper)
        {
            _httpClient = new HttpClient();
            _apiBaseUrl = apiBaseUrl;
            _mapper = mapper;
        }
        public async Task<WatchViewModel> CreateWatchAsync(CreateViewModel model)
        {
            string endpoint = $"{_apiBaseUrl}/Watches/create";

            var watch = _mapper.Map<WatchViewModel>(model);

            if (model.Photo != null)
            {
                var photoResponse = await FileUploadAsync(model.Photo);
                if (!String.IsNullOrEmpty(photoResponse.Blob.Uri))
                {
                    watch.PhotoUri = photoResponse.Blob.Uri;
                }

            }

            var options = new JsonSerializerOptions { PropertyNamingPolicy = JsonNamingPolicy.CamelCase };
            var json = JsonSerializer.Serialize(watch, options);
            var content = new StringContent(json, Encoding.UTF8, "application/json");

            // Send the POST request
            HttpResponseMessage response = await _httpClient.PostAsync(endpoint, content);

            if (response.IsSuccessStatusCode)
            {
                options = new JsonSerializerOptions { PropertyNameCaseInsensitive = true };
                string responseBody = await response.Content.ReadAsStringAsync();
                WatchViewModel responseObject = JsonSerializer.Deserialize<WatchViewModel>(responseBody, options);

                if (responseObject != null) return responseObject;
            }

            return new WatchViewModel();

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

        public async Task<WatchViewModel> DeleteWatchByIdAsync(int id)
        {
            string endpoint = $"{_apiBaseUrl}/Watches/remove-item/id/{id}";

            // Send the POST request
            HttpResponseMessage response = await _httpClient.DeleteAsync(endpoint);

            if (response.IsSuccessStatusCode)
            {
                var responseStream = await response.Content.ReadAsStreamAsync();

                // Deserialize the response content using System.Text.Json
                var responseContent = await JsonSerializer.DeserializeAsync<WatchViewModel>(responseStream);

                if (responseContent != null) return responseContent;
            }

            return new WatchViewModel();
        }

        public async Task<WatchViewModel> GetWatchByIdAsync(int id)
        {
            string endpoint = $"{_apiBaseUrl}/Watches/id/{id}";

            HttpResponseMessage response = await _httpClient.GetAsync(endpoint);

            if (response.IsSuccessStatusCode)
            {
                string responseContent = await response.Content.ReadAsStringAsync();
                var watch = JsonSerializer.Deserialize<WatchViewModel>(responseContent,
                new JsonSerializerOptions { PropertyNameCaseInsensitive = true });
                return watch;
            }
            else
            {
                throw new HttpRequestException($"API call failed with status code: {response.StatusCode}");
            }
        }

        public async Task<WatchViewModel> GetWatchByItemNumberAsync(string itemNumber)
        {
            string endpoint = $"{_apiBaseUrl}/Watches/item/{itemNumber}";

            HttpResponseMessage response = await _httpClient.GetAsync(endpoint);

            if (response.IsSuccessStatusCode)
            {
                string responseContent = await response.Content.ReadAsStringAsync();
                var watch = JsonSerializer.Deserialize<WatchViewModel>(responseContent,
                new JsonSerializerOptions { PropertyNameCaseInsensitive = true });
                return watch;
            }
            else
            {
                throw new HttpRequestException($"API call failed with status code: {response.StatusCode}");
            }
        }

        public async Task<WatchViewModel> UpdateWatchAsync(UpdateViewModel model)
        {
            string endpoint = $"{_apiBaseUrl}/Watches/update";

            if (model.Photo != null) 
            {
               var photoResponse = await FileUploadAsync(model.Photo);
                if (!String.IsNullOrEmpty(photoResponse.Blob.Uri))
                {
                    model.PhotoUri = photoResponse.Blob.Uri;
                }

            }

            var watch = _mapper.Map<WatchViewModel>(model);

            var options = new JsonSerializerOptions { PropertyNamingPolicy = JsonNamingPolicy.CamelCase };
            var json = JsonSerializer.Serialize(watch, options);
            var content = new StringContent(json, Encoding.UTF8, "application/json");

            // Send the POST request
            HttpResponseMessage response = await _httpClient.PutAsync(endpoint, content);

            if (response.IsSuccessStatusCode)
            {
                options = new JsonSerializerOptions { PropertyNameCaseInsensitive = true };
                string responseBody = await response.Content.ReadAsStringAsync();
                WatchViewModel responseObject = JsonSerializer.Deserialize<WatchViewModel>(responseBody, options);

                if (responseObject != null) return responseObject;
            }

            return new WatchViewModel();
        }

        public async Task<BlobResponseDTO> FileUploadAsync(IFormFile photo)
        {
            string endpoint = $"{_apiBaseUrl}/Files/upload-file";

            string base64String;

            using (var memoryStream = new MemoryStream())
            {
                await photo.CopyToAsync(memoryStream);
                byte[] bytes = memoryStream.ToArray();
                base64String = Convert.ToBase64String(bytes);
            }

            var photoModel = new PhotoDTO { FileName = photo.FileName, Base64Data = base64String };
            var options = new JsonSerializerOptions { PropertyNamingPolicy = JsonNamingPolicy.CamelCase };
            var json = JsonSerializer.Serialize(photoModel, options);
            var content = new StringContent(json, Encoding.UTF8, "application/json");


            // Send the POST request
            _httpClient.Timeout = TimeSpan.FromSeconds(30);
            HttpResponseMessage response = await _httpClient.PostAsync(endpoint, content);

            if (response.IsSuccessStatusCode)
            {
                options = new JsonSerializerOptions { PropertyNameCaseInsensitive = true };
                string responseBody = await response.Content.ReadAsStringAsync();
                BlobResponseDTO responseObject = JsonSerializer.Deserialize<BlobResponseDTO>(responseBody, options);


                if (responseObject != null) return responseObject;
            }

            return new BlobResponseDTO();
        }
    }
}
