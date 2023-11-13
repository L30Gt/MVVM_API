using CommunityToolkit.Mvvm.ComponentModel;
using MVVM_API_SampleProject.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using System.Windows.Input;

namespace MVVM_API_SampleProject.ViewModels
{
    internal partial class PostViewModel : ObservableObject, IDisposable
    {
        HttpClient client;

        JsonSerializerOptions _serializerOptions;
        string baseUrl = "http://jsonplaceholder.typicode.com";

        [ObservableProperty]
        public int _UserId;
        [ObservableProperty]
        public int _Id;
        [ObservableProperty]
        public int _Title;
        [ObservableProperty]
        public int _Body;
        [ObservableProperty]
        public ObservableCollection<Post> _posts;

        public PostViewModel()
        {
            client = new HttpClient();
            Posts = new ObservableCollection<Post>();
            _serializerOptions = new JsonSerializerOptions { PropertyNameCaseInsensitive = true };
        }

        public ICommand GetPostsCommand => new Command(async () => await LoadPostsAsync());

        private async Task LoadPostsAsync()
        {
            var url = $"{baseUrl}/posts";
            try
            {
                var response = await client.GetAsync(url);
                if (response.IsSuccessStatusCode)
                {
                    string content = await response.Content.ReadAsStringAsync();
                    Posts = JsonSerializer.Deserialize<ObservableCollection<Post>>(content, _serializerOptions);
                }
            }
            catch (Exception e) 
            {
                Debug.WriteLine(e.Message);
            }
        }

        public void Dispose()
        {
            throw new NotImplementedException();
        }
    }
}
