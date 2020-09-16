using SQLite;
using System;
using System.Collections.Generic;
using System.Text;

namespace DeliveryApp.Models
{
  public interface ISQLite
    {
        SQLiteConnection GetConnection();
    }
}
