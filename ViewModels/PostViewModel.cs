using CommunityToolkit.Mvvm.ComponentModel;
using MVVM_API_SampleProject.Models;
using MVVM_API_SampleProject.Services;
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
        private readonly PostService _service;

        [ObservableProperty] 
        public ObservableCollection<Post> _posts;

        public ICommand GetPostsCommand { get; }

        public PostViewModel()
        {
            Posts = new ObservableCollection<Post>();
            _service = new PostService();
            GetPostsCommand = new Command(async () => await LoadPostsAsync());
            Task.Run(async () => await LoadPostsAsync());
        }

        private async Task LoadPostsAsync()
        {
            Posts = await _service.GetPostsAsync();
        }

        public void Dispose()
        {
            throw new NotImplementedException();
        }
    }
}
