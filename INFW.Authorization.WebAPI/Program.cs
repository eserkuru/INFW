using Autofac;
using Autofac.Extensions.DependencyInjection;
using INFW.Authorization.Business.DependencyResolvers.Autofac;
using INFW.Core.Utilities.Configurations.Database;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Hosting;

namespace INFW.Authorization.WebAPI
{
    public class Program
    {
        public static void Main(string[] args)
        {
            CreateHostBuilder(args).Build().Run();
        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .UseServiceProviderFactory(new AutofacServiceProviderFactory())
                .ConfigureContainer<ContainerBuilder>(builder =>
                {
                    builder.RegisterModule(new AutofacAuthorizationBusinessModule());
                    builder.RegisterModule(
                        new AutofacAuthorizationDataAccessModule(
                            new DbSetting("Authorization").DetectDatabaseProvider())
                        );
                })
                .ConfigureWebHostDefaults(webBuilder =>
                {
                    webBuilder.UseStartup<Startup>();
                });
    }
}
