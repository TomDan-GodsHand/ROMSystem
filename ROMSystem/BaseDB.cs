using SqlSugar;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ROMSystem
{
    public class BaseDB
    {
        public static string ConnectionString =  System.Configuration.ConfigurationManager.ConnectionStrings["SqlConnectionString"].ConnectionString;

        public static SqlSugarClient GetDB()
        {
            var db = new SqlSugarClient(new ConnectionConfig()
            {
                DbType = SqlSugar.DbType.Sqlite,
                ConnectionString = ConnectionString,
                IsAutoCloseConnection = true,
            });
            return db;
        }
    }
}
