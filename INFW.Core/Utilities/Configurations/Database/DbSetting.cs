using INFW.Core.DataAccess;
using INFW.Core.Utilities.Configurations.Database.Enums;
using Microsoft.Extensions.Configuration;
using System.IO;

namespace INFW.Core.Utilities.Configurations.Database
{
    public class DbSetting : IDbSetting
    {
        public string Engine { get; set; }
        public string Host { get; set; }
        public string Port { get; set; }
        public string Catalog { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }

        public DbSetting(string moduleName = "Default")
        {
            var builder = new ConfigurationBuilder()
                            .SetBasePath(Directory.GetCurrentDirectory())
                            .AddJsonFile("appsettings.json")
                            .Build();

            var settings = builder.GetSection("DatabaseSettings").GetSection(moduleName);
            // TODO: iyileştirilebilir.
            Engine = settings.GetSection("Engine").Value;
            Host = settings.GetSection("Host").Value;
            Port = settings.GetSection("Port").Value;
            Catalog = settings.GetSection("Catalog").Value;
            Username = settings.GetSection("Username").Value;
            Password = settings.GetSection("Password").Value;
        }

        public string ConnectionForEfCore(EfCoreDbEngine dbEngine)
        {
            switch (dbEngine)
            {
                case EfCoreDbEngine.SqlServer:
                    var dataSource = Host;
                    if (Port != "")
                        dataSource = Host + "," + Port;
                    return @"Data Source=" + dataSource
                        + ";Initial Catalog=" + Catalog
                        + ";User Id=" + Username
                        + ";Password=" + Password;
                //+ ";Integrated Security=True;MultipleActiveResultSets=True";

                case EfCoreDbEngine.PostgreSQL:
                    var postgresqlPort = Port;
                    if (Port != "")
                        postgresqlPort = "Port=" + Port + ";";
                    return "Host=" + Host + ";" + postgresqlPort + "Database=" + Catalog + ";Username=" + Username + ";Password=" + Password;

                case EfCoreDbEngine.MySql:
                    var mysqlPort = Port;
                    if (Port != "")
                        mysqlPort = "port=" + Port + ";";
                    return "server=" + Host + ";" + mysqlPort + "database=" + Catalog + ";user=" + Username + ";password=" + Password;

                default:
                    return "";
            }
        }

        public string ConnectionForNhibernate(NhDbEngine dbEngine)
        {
            // TODO : Case'ler doldurulmalıdır.
            switch (dbEngine)
            {
                case NhDbEngine.SqlServer:
                    var dataSource = Host;
                    if (Port != "")
                        dataSource = Host + "," + Port;

                    return @"Data Source=" + dataSource
                        + ";Initial Catalog=" + Catalog
                        + "; Integrated Security=True;MultipleActiveResultSets=True";

                case NhDbEngine.Oracle:
                default:
                    return "";
            }

        }

        public string ConnectionForMongoDbDriver()
        {
            var port = Port;
            if (Port != "")
                port = ":27017" + Port;
            return "mongodb://" + Host + port;
        }

        public DataAccessProvider DetectDatabaseProvider()
        {
            return Engine switch
            {
                "Oracle" => DataAccessProvider.NHibernate,
                "MongoDb" => DataAccessProvider.MongoDbDriver,
                _ => DataAccessProvider.EntityFrameworkCore,
            };
        }
    }
}
