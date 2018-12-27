using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using Dapper;
using System.Linq;
using MyWebsite.Models;
using System.Collections.Generic;
using Microsoft.Data.Sqlite;

namespace MyWebsite
{
    public static class DataAccess
    {
        public static string GetIdUsingName(string name)
        {
            
            string query = "select Id from AspNetUsers where UserName = @Name;";
            return QueryDb(query, new { Name = name }).AsList()[0].Id;
        }

        public static IEnumerable<dynamic> QueryDb(string sql, object model = null)
        {
            using (SqliteConnection db = new SqliteConnection("DataSource=app.db"))
            {
                if (model != null)
                {
                    return db.Query(sql, model);
                }
                else
                {
                    return db.Query(sql);
                }
            }
        }

        public static void ExecuteDb(string sql, object model = null)
        {
            using (SqliteConnection db = new SqliteConnection("DataSource=app.db"))
            {
                if (model != null)
                {
                    db.Execute(sql, model);
                }
                else
                {
                    db.Execute(sql);
                }
            }
        }
    
    }


}