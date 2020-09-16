using System;

using System.IO;

using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using DeliveryApp.Droid;
using DeliveryApp.Models;
using SQLite;
using Xamarin.Forms;

[assembly: Dependency(typeof(SQLite_Android))]
namespace DeliveryApp.Droid
{
    class SQLite_Android : ISQLite
    { 

        SQLiteConnection ISQLite.GetConnection()
        {
            var sqliteFileName = "MyDatabase.db3";
            string documentPath = System.Environment.GetFolderPath(System.Environment.SpecialFolder.Personal);
            string path = Path.Combine(documentPath, sqliteFileName);
            var cn = new SQLiteConnection(path);
            return cn;
        }
    }
}