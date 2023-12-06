using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using MVVM_API_SampleProject.Models;
using MVVM_API_SampleProject.Utils;

namespace MVVM_API_SampleProject.Services
{
    public class PostService
    {
        private readonly HttpClient _httpClient;
        private readonly JsonSerializerOptions _serializerOptions;
        private readonly string _baseUrl = Variables.BaseUrl;


        public PostService()
        {
            _httpClient = new HttpClient();
            _serializerOptions = new JsonSerializerOptions { PropertyNameCaseInsensitive = true };
        }

        public async Task<ObservableCollection<Post>> GetPostsAsync()
        {
            var url = $"{_baseUrl}/posts";
            try
            {
                var response = await _httpClient.GetAsync(url);
                if (response.IsSuccessStatusCode)
                {
                    string content = await response.Content.ReadAsStringAsync();
                    return JsonSerializer.Deserialize<ObservableCollection<Post>>(content, _serializerOptions);
                }
                return null;
            }

            catch (Exception ex)
            {
                Console.WriteLine(ex);
                throw new Exception(ex.Message);
            }
        }
    }
}
