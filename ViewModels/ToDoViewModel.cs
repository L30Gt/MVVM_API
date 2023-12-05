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
using MVVM_API_SampleProject.Services;

namespace MVVM_API_SampleProject.ViewModels
{
    internal partial class ToDoViewModel : ObservableObject, IDisposable
    {
        private readonly ToDoService _service;

        [ObservableProperty]
        public ObservableCollection<ToDo> _todos;

        public ICommand GetToDosCommand { get; }
        public ToDoViewModel()
        {
            Todos = new ObservableCollection<ToDo>();
            _service = new ToDoService();
            GetToDosCommand = new Command(async () => await LoadToDosAsync());
            Task.Run(async () => await LoadToDosAsync());
        }

        private async Task LoadToDosAsync()
        {
            Todos = await _service.GetToDoAsync();
        }

        public void Dispose()
        {
            throw new NotImplementedException();
        }

    }
}
