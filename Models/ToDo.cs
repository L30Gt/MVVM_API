using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;


namespace MVVM_API_SampleProject.Models
{
    public class ToDo : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
        public int UserId { get; set; }
        public int Id { get; set; }
        public string Title { get; set; }

        private bool _completed;
        public bool Completed
        {
            get => _completed;
            set
            {
                _completed = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(Completed)));
            }
        }
    }
}
