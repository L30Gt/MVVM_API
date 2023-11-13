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
    internal partial class ToDoViewModel : ObservableObject, IDisposable
    {
        HttpClient client;

        JsonSerializerOptions _serializerOptions;
        string baseUrl = "https://jsonplaceholder.typicode.com";

        [ObservableProperty]
        public int _UserId;
        [ObservableProperty]
        public int _Id;
        [ObservableProperty]
        public string _Title;
        [ObservableProperty]
        public bool _Completed;
        [ObservableProperty]
        public ObservableCollection<ToDo> _todos;

        public ToDoViewModel()
        {
            client = new HttpClient();
            Todos = new ObservableCollection<ToDo>();
            _serializerOptions = new JsonSerializerOptions { PropertyNameCaseInsensitive = true };
        }

        public ICommand GetToDosCommand => new Command(async () => await LoadToDosAsync());

        private async Task LoadToDosAsync()
        {
            var url = $"{baseUrl}/todos";
            try
            {
                var response = await client.GetAsync(url);
                if (response.IsSuccessStatusCode)
                {
                    string content = await response.Content.ReadAsStringAsync();
                    Todos = JsonSerializer.Deserialize<ObservableCollection<ToDo>>(content, _serializerOptions);
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