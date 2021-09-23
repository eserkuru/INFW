using INFW.Core.Utilities.Configurations.Database;
using MongoDB.Driver;
using System;

namespace INFW.Core.DataAccess.MongoDbDriver.Configuration
{
    public class DbClientHelper : IDbClientHelper, IMongoDbClient
    {
        public IMongoDatabase Database { get; set; }

        public DbClientHelper(string moduleName = "Default")
        {
            var dbSetting = new DbSetting(moduleName);
            if (moduleName != "Default")
            {
                var settings = new DbSetting(moduleName);
                if (settings.Engine == null)
                    dbSetting = new DbSetting("Default");
            }
            Database = new MongoClient(dbSetting.ConnectionForMongoDbDriver()).GetDatabase(dbSetting.Catalog);
        }

        public void Dispose()
        {
            GC.SuppressFinalize(this);
        }
    }
}
