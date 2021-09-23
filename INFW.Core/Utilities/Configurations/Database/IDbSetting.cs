using INFW.Core.DataAccess;
using INFW.Core.Utilities.Configurations.Database.Enums;
using MongoDB.Driver;

namespace INFW.Core.Utilities.Configurations.Database
{
    public interface IDbSetting
    {
        public string Engine { get; set; }
        public string Host { get; set; }
        public string Port { get; set; }
        public string Catalog { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }

        string ConnectionForEfCore(EfCoreDbEngine dbEngine);
        string ConnectionForNhibernate(NhDbEngine dbEngine);
        string ConnectionForMongoDbDriver();

        DataAccessProvider DetectDatabaseProvider();
    }
}
