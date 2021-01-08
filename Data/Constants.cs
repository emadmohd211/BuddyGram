using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using Xamarin.Forms;

namespace Buddiegram.Data
{
    public static class Constants
    {
        // URL of REST service
        public static string RestUrl = Device.RuntimePlatform == Device.Android ? "https://23b6ae00.ngrok.io/{0}" : "https://23b6ae00.ngrok.io/{0}";

        public const string DatabaseFilename = "BuddyUserSQLite.db3";

        public const SQLite.SQLiteOpenFlags Flags =
            // open the database in read/write mode
            SQLite.SQLiteOpenFlags.ReadWrite |
            // create the database if it doesn't exist
            SQLite.SQLiteOpenFlags.Create |
            // enable multi-threaded database access
            SQLite.SQLiteOpenFlags.SharedCache;

        public static string DatabasePath
        {
            get
            {
                var basePath = Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData);
                return Path.Combine(basePath, DatabaseFilename);
            }
        }
    }
}
