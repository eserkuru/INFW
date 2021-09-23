using System.Reflection;
using INFW.Core.DataAccess.NHibernate;
using NHibernate;
using FluentNHibernate.Cfg;
using FluentNHibernate.Cfg.Db;
using INFW.Core.Utilities.Configurations.Database;
using INFW.Core.Utilities.Configurations.Database.Enums;

namespace INFW.Authorization.DataAccess.Concrete.NHibernate.Helpers
{
    public class SqlServerHelper : NHibernateHelper
    {
        private IDbSetting DbSetting { get; set; }

        public SqlServerHelper()
        {
            DbSetting = new DbSetting("Authorization");
        }

        protected override ISessionFactory InitializeFactory()
        {
            return Fluently.Configure().Database(MsSqlConfiguration.MsSql2012.ConnectionString(
                        DbSetting.ConnectionForNhibernate(NhDbEngine.SqlServer))
                    .ShowSql()).Mappings(m => m.FluentMappings.AddFromAssembly(Assembly.GetExecutingAssembly()))
                .BuildSessionFactory();
        }
    }
}
