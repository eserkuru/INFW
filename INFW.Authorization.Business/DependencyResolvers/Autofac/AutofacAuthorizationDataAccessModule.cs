using Autofac;
using INFW.Authorization.DataAccess.Abstract;
using INFW.Authorization.DataAccess.Concrete.EntityFrameworkCore.Dals;
using INFW.Authorization.DataAccess.Concrete.MongoDbDriver.Dals;
using INFW.Authorization.DataAccess.Concrete.NHibernate.Dals;
using INFW.Authorization.DataAccess.Concrete.NHibernate.Helpers;
using INFW.Core.DataAccess;
using INFW.Core.DataAccess.NHibernate;

namespace INFW.Authorization.Business.DependencyResolvers.Autofac
{
    public class AutofacAuthorizationDataAccessModule : Module
    {
        private DataAccessProvider DataAccessType { get; set; }
        public AutofacAuthorizationDataAccessModule(DataAccessProvider dataAccessType = DataAccessProvider.EntityFrameworkCore)
        {
            DataAccessType = dataAccessType;
        }
        protected override void Load(ContainerBuilder builder)
        {
            switch (DataAccessType)
            {
                case DataAccessProvider.EntityFrameworkCore:
                default:
                    builder.RegisterType<EfUserDal>().As<IUserDal>();
                    builder.RegisterType<EfUserRoleDal>().As<IUserRoleDal>();
                    builder.RegisterType<EfRoleDal>().As<IRoleDal>();
                    break;
                case DataAccessProvider.NHibernate:
                    builder.RegisterType<SqlServerHelper>().As<NHibernateHelper>();
                    builder.RegisterType<NhUserDal>().As<IUserDal>();
                    builder.RegisterType<NhUserRoleDal>().As<IUserRoleDal>();
                    builder.RegisterType<NhRoleDal>().As<IRoleDal>();
                    break;
                case DataAccessProvider.MongoDbDriver:
                    builder.RegisterType<MongoUserDal>().As<IUserDal>();
                    builder.RegisterType<MongoUserRoleDal>().As<IUserRoleDal>();
                    builder.RegisterType<MongoRoleDal>().As<IRoleDal>();
                    break;
            }
        }
    }
}
