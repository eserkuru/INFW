using INFW.Authorization.DataAccess.Concrete.EntityFrameworkCore.Mappings;
using INFW.Authorization.Entities.Concrete;
using INFW.Core.DataAccess.EntityFrameworkCore.Configuration;
using Microsoft.EntityFrameworkCore;

namespace INFW.Authorization.DataAccess.Concrete.EntityFrameworkCore.Contexts
{
    public class AuthorizationContext : DbContextHelper
    {
        public AuthorizationContext() : base("Authorization") { }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new UserMap());
            modelBuilder.ApplyConfiguration(new RoleMap());
            modelBuilder.ApplyConfiguration(new UserRoleMap());
        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.UseEngine(optionsBuilder);
        }
        public DbSet<User> Users { get; set; }
        public DbSet<Role> Roles { get; set; }
        public DbSet<UserRole> UserRoles { get; set; }
    }
}
