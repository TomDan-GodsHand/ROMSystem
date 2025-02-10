using SqlSugar;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ROMSystem
{
    public static class DataBase
    {
        public static string ConnectionString = @"DataSource=ROM_SQL.sqlite";

        public static SqlSugarClient GetDB()
        {
            var db = new SqlSugarClient(new ConnectionConfig()
            {
                DbType = SqlSugar.DbType.Sqlite,
                ConnectionString = ConnectionString,
                IsAutoCloseConnection = true,
            });
            return db
        }
    }
}
