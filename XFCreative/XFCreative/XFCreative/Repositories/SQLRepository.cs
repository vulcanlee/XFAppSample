using SQLite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using XFCreative.Services;

namespace XFCreative.Repositories
{
    public class SQLRepository<T> where T : class, new()
    {
        static object locker = new object();
        public string DBPath { get; set; }
        public SQLiteConnection database;
        public SQLRepository()
        {
            database = DependencyService.Get<ISQLite>().GetConnection();
            DBPath = database.DatabasePath;
            // create the tables
            database.CreateTable<T>();
        }

        public Task<List<T>> GetAllAsync()
        {
            lock (locker)
            {
                var tcs = new TaskCompletionSource<List<T>>();
                Task.Run(() =>
                {
                    //var fooItems = (from i in database.Table<T>() select i).ToList();
                    var fooItems = database.Table<T>().ToList();
                    tcs.SetResult(fooItems);
                });
                return tcs.Task;
            }
        }

        public Task InsertAsync(T item)
        {
            lock (locker)
            {
                return Task.Run(() =>
                {
                    database.Insert(item);
                });
            }
        }

        public Task UpdateAsync(T item)
        {
            lock (locker)
            {
                return Task.Run(() =>
                {
                    database.Update(item);
                });
            }
        }

        public Task DeleteAsync(T item)
        {
            lock (locker)
            {
                return Task.Run(() =>
                {
                    database.Delete(item);
                });
            }
        }
    }
}
