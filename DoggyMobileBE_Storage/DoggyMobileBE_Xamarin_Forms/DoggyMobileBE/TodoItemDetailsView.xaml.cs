using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections.ObjectModel;
using Microsoft.WindowsAzure.MobileServices.Files;

using Xamarin.Forms;

namespace DoggyMobileBE
{
    public partial class TodoItemDetailsView : ContentPage
    {
        private TodoItemManager manager;

        public TodoItem TodoItem { get; set; }
        public ObservableCollection<TodoItemImage> Images { get; set; }

        public TodoItemDetailsView(TodoItem todoItem, TodoItemManager manager)
        {
            InitializeComponent();
            this.Title = todoItem.Name;

            this.TodoItem = todoItem;
            this.manager = manager;

            this.Images = new ObservableCollection<TodoItemImage>();
            this.BindingContext = this;
        }

        public async Task LoadImagesAsync()
        {
            IEnumerable<MobileServiceFile> files = await this.manager.GetImageFilesAsync(TodoItem);
            this.Images.Clear();

            foreach (var f in files)
            {
                var todoImage = new TodoItemImage(f, this.TodoItem);
                this.Images.Add(todoImage);
            }
        }

        public async void OnAdd(object sender, EventArgs e)
        {
            IPlatform mediaProvider = DependencyService.Get<IPlatform>();
            string sourceImagePath = await mediaProvider.TakePhotoAsync(App.UIContext);

            if (sourceImagePath != null)
            {
                MobileServiceFile file = await this.manager.AddImage(this.TodoItem, sourceImagePath);

                var image = new TodoItemImage(file, this.TodoItem);
                this.Images.Add(image);
            }
        }
    }
}
