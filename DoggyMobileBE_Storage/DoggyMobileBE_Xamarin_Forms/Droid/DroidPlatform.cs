using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using System.Threading.Tasks;
using Microsoft.WindowsAzure.MobileServices.Sync;
using Microsoft.WindowsAzure.MobileServices.Files.Metadata;
using Microsoft.WindowsAzure.MobileServices.Files;
using Microsoft.WindowsAzure.MobileServices.Files.Sync;
using System.IO;
using Xamarin.Media;

[assembly: Xamarin.Forms.Dependency(typeof(DoggyMobileBE.Droid.DroidPlatform))]
namespace DoggyMobileBE.Droid
{
    public class DroidPlatform : IPlatform
    {
        public async Task DownloadFileAsync<T>(IMobileServiceSyncTable<T> table, MobileServiceFile file, string filename)
        {
            var path = await FileHelper.GetLocalFilePathAsync(file.ParentId, file.Name);
            await table.DownloadFileAsync(file, path);
        }

        public async Task<IMobileServiceFileDataSource> GetFileDataSource(MobileServiceFileMetadata metadata)
        {
            var filePath = await FileHelper.GetLocalFilePathAsync(metadata.ParentDataItemId, metadata.FileName);
            return new PathMobileServiceFileDataSource(filePath);
        }

        public async Task<string> TakePhotoAsync(object context)
        {
            try
            {
                var uiContext = context as Context;
                if (uiContext != null)
                {
                    var mediaPicker = new MediaPicker(uiContext);
                    var photo = await mediaPicker.TakePhotoAsync(new StoreCameraMediaOptions());

                    return photo.Path;
                }
            }
            catch (TaskCanceledException)
            {
            }

            return null;
        }

        public Task<string> GetTodoFilesPathAsync()
        {
            string appData = System.Environment.GetFolderPath(System.Environment.SpecialFolder.MyDocuments);
            string filesPath = Path.Combine(appData, "TodoItemFiles");

            if (!Directory.Exists(filesPath))
            {
                Directory.CreateDirectory(filesPath);
            }

            return Task.FromResult(filesPath);
        }
    }
}