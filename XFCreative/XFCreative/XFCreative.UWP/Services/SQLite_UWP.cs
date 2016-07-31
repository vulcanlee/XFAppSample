using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.Storage;
using Xamarin.Forms;
using XFCreative.Services;
using XFCreative.UWP.Services;

[assembly: Dependency(typeof(SQLite_UWP))]
namespace XFCreative.UWP.Services
{
    public class SQLite_UWP : ISQLite
    {
        public SQLite_UWP()
        {
        }
        #region ISQLite implementation
        public SQLite.SQLiteConnection GetConnection()
        {
            var sqliteFilename = "DoggyDB.db3";
            string path = Path.Combine(ApplicationData.Current.LocalFolder.Path, sqliteFilename);

            var conn = new SQLite.SQLiteConnection(path);

            // Return the database connection 
            return conn;
        }
        #endregion
    }
}
