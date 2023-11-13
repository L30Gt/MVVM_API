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
    internal partial class UserViewModel : ObservableObject, IDisposable
    {
        HttpClient client;

        JsonSerializerOptions _serializerOptions;
        string baseUrl = "https://jsonplaceholder.typicode.com";

        [ObservableProperty]
        public int _Id;
        [ObservableProperty]
        public string _Name;
        [ObservableProperty]
        public string _Username;
        [ObservableProperty]
        public string _Email;
        [ObservableProperty]
        public Address _Address;
        [ObservableProperty]
        public string _Phone;
        [ObservableProperty]
        public string _Website;
        [ObservableProperty]
        public Company _Company;

        //Address
        [ObservableProperty]
        public string _Street;
        [ObservableProperty]
        public string _Suite;
        [ObservableProperty]
        public string _City;
        [ObservableProperty]
        public string _Zipcode;
        [ObservableProperty]
        public Geo _Geo;

        //Geo
        [ObservableProperty]
        public string _Lat;
        [ObservableProperty]
        public string _Lng;

        //Company
        [ObservableProperty]
        public string _CompanyName;
        [ObservableProperty]
        public string _CatchPhrase;
        [ObservableProperty]
        public string _Bs;

        [ObservableProperty]
        public ObservableCollection<User> _users;

        public UserViewModel()
        {
            client = new HttpClient();
            Users = new ObservableCollection<User>();
            _serializerOptions = new JsonSerializerOptions { PropertyNameCaseInsensitive = true };

        }

        public ICommand GetUsersCommand => new Command(async () => await LoadUsersAsync());

        private async Task LoadUsersAsync()
        {
            var url = $"{baseUrl}/users";
            try
            {
                var response = await client.GetAsync(url);
                if (response.IsSuccessStatusCode)
                {
                    string content = await response.Content.ReadAsStringAsync();
                    Users = JsonSerializer.Deserialize<ObservableCollection<User>>(content, _serializerOptions);
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
