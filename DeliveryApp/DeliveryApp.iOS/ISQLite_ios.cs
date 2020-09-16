using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
 
using System.Text;
 
using DeliveryApp.Models;
using Foundation;
using SQLite;

using UIKit;
using Xamarin.Forms;

[assembly: Dependency(typeof(DeliveryApp.iOS.ISQLite_ios))]
namespace DeliveryApp.iOS
{
   public class ISQLite_ios : ISQLite
    {
        public SQLiteConnection GetConnection()
        {
            var sqliteFileName = "MyDatabase.db3";
            string documentPath = Environment.GetFolderPath(Environment.SpecialFolder.Personal);
            string libraryPath = Path.Combine(documentPath, "..", "Library");
            string path = Path.Combine(libraryPath, sqliteFileName);
            var cn = new  SQLiteConnection(path);
            return cn;
        }
    }
}