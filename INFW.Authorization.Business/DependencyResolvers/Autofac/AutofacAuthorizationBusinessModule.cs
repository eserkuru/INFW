using Autofac;
using INFW.Authorization.Business.Abstract;
using INFW.Authorization.Business.Concrete.Managers;

namespace INFW.Authorization.Business.DependencyResolvers.Autofac
{
    public class AutofacAuthorizationBusinessModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterType<UserManager>().As<IUserService>();
            builder.RegisterType<RoleManager>().As<IRoleService>();
        }
    }
}
