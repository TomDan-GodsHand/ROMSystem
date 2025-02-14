using SqlSugar;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ROMSystem
{
    public class DB
    {
        public static string ConnectionString =  System.Configuration.ConfigurationManager.ConnectionStrings["SqlConnectionString"].ConnectionString;

        public static SqlSugarClient GetDB()
        {
            var db = new SqlSugarClient(new ConnectionConfig()
            {
                DbType = DbType.Sqlite,
                ConnectionString = ConnectionString,
                InitKeyType = InitKeyType.Attribute,
                IsAutoCloseConnection = true,
                MoreSettings = new ConnMoreSettings()
                {
                    SqliteCodeFirstEnableDescription = true //启用备注
                }
            });
            return db;
        }
        public static void CodeFirst()
        {
            var db = GetDB();
            db.DbMaintenance.CreateDatabase();
            db.CodeFirst.SetStringDefaultLength(200).InitTables(typeof(MaintenanceForm));
        }

        public static void Insert(MaintenanceForm maintenanceForm)
        {
            try
            {
                using(var db = GetDB())
                {
                    db.Insertable(maintenanceForm).ExecuteCommand();
                }
            }
            catch {  }

        }
    }
}
