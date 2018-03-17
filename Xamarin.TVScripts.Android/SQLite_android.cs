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
using System.IO;
using SQLite;
using Xamarin.TVScripts.Droid;
using Xamarin.TVScripts.Data;

[assembly: Xamarin.Forms.Dependency(typeof(SQLite_android))]
namespace Xamarin.TVScripts.Droid
{
    class SQLite_android : ISQLite
    {
        private const string dbFileName = "TVScripts.db3";

        public SQLiteConnection GetConnection()
        {
            string dbPath = Path.Combine(
                System.Environment
                    .GetFolderPath(System.Environment.SpecialFolder.Personal),
                        dbFileName);

            return new SQLite.SQLiteConnection(dbPath);
        }
    }
}