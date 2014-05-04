using SmithJessicaHW5.Migrations;
using System;
using System.Collections.Generic;
using System.Data.Entity.Migrations;
using System.Linq;
using System.Web;
using WebMatrix.WebData;

namespace SmithJessicaHW5.App_Start
{
    public class AppInitialize
    {
        public static void InitSecurity()
        {
            if (!WebSecurity.Initialized)
            {
                WebSecurity.InitializeDatabaseConnection("DefaultConnection", "UserProfile", "UserId", "UserName",
            autoCreateTables: true);
            }
        }

        public static void DoMigration()
        {
            var migrator = new DbMigrator(new Configuration());
            migrator.Update();
        }
    }
}