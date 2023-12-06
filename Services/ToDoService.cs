using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MVVM_API_SampleProject.Utils;
using MVVM_API_SampleProject.Models;
using System.Text.Json;
using MVVM_API_SampleProject.ViewModels;
using System.Collections.ObjectModel;

namespace MVVM_API_SampleProject.Services
{
    public class ToDoService
    {
        private readonly HttpClient _httpClient;
        private readonly JsonSerializerOptions _serializerOptions;
        private readonly string _baseUrl = Variables.BaseUrl;

        public ToDoService()
        {
            _httpClient = new HttpClient();
            _serializerOptions = new JsonSerializerOptions { PropertyNameCaseInsensitive = true };
        }

        public async Task<ObservableCollection<ToDo>> GetToDoAsync()
        {
            var url = $"{_baseUrl}/todos";
            try
            {
                var response = await _httpClient.GetAsync(url);
                if (response.IsSuccessStatusCode)
                {
                    string content = await response.Content.ReadAsStringAsync();
                    return JsonSerializer.Deserialize<ObservableCollection<ToDo>>(content, _serializerOptions);
                }
                return null;
            }

            catch (Exception ex)
            {
                Console.WriteLine(ex);
                throw new Exception(ex.Message);
            }
        }

        internal Task<ToDo> GetToDosAsync()
        {
            throw new NotImplementedException();
        }
    }
}
