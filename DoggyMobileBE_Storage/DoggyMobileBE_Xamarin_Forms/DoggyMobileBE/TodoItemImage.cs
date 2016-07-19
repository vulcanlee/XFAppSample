using Microsoft.WindowsAzure.MobileServices.Files;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DoggyMobileBE
{
    public class TodoItemImage : INotifyPropertyChanged
    {
        private string name;
        private string uri;

        public MobileServiceFile File { get; private set; }

        public string Name
        {
            get { return name; }
            set
            {
                name = value;
                OnPropertyChanged(nameof(Name));
            }
        }

        public string Uri
        {
            get { return uri; }
            set
            {
                uri = value;
                OnPropertyChanged(nameof(Uri));
            }
        }

        public TodoItemImage(MobileServiceFile file, TodoItem todoItem)
        {
            Name = file.Name;
            File = file;

            FileHelper.GetLocalFilePathAsync(todoItem.Id, file.Name).ContinueWith(x => this.Uri = x.Result);
        }

        public event PropertyChangedEventHandler PropertyChanged;

        private void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
