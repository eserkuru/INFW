using INFW.Core.Utilities.Configurations.Database;
using INFW.Core.Utilities.Configurations.Database.Enums;
using Microsoft.EntityFrameworkCore;

namespace INFW.Core.DataAccess.EntityFrameworkCore.Configuration
{
    public class DbContextHelper : DbContext, IDbContextHelper
    {
        private IDbSetting DbSetting { get; set; }

        public DbContextHelper(string moduleName = "Default")
        {
            DbSetting = new DbSetting(moduleName);
            if (moduleName != "Default")
            {
                var settings = new DbSetting(moduleName);
                if (settings.Engine == null)
                    DbSetting = new DbSetting("Default");
            }
        }
        public virtual void UseEngine(DbContextOptionsBuilder optionsBuilder)
        {
            switch (DbSetting.Engine)
            {
                case "SqlServer":
                    optionsBuilder.UseSqlServer(DbSetting.ConnectionForEfCore(EfCoreDbEngine.SqlServer));
                    break;
                case "PostgreSql":
                    optionsBuilder.UseNpgsql(DbSetting.ConnectionForEfCore(EfCoreDbEngine.PostgreSQL));
                    break;
                case "MySql":
                    optionsBuilder.UseMySQL(DbSetting.ConnectionForEfCore(EfCoreDbEngine.MySql));
                    break;
            }
        }
    }
}
