using INFW.Authorization.Entities.Concrete;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace INFW.Authorization.DataAccess.Concrete.EntityFrameworkCore.Mappings
{
    public class UserRoleMap : IEntityTypeConfiguration<UserRole>
    {
        public void Configure(EntityTypeBuilder<UserRole> builder)
        {
            builder.ToTable(@"UserRoles");
            builder.HasKey(t => t.Id);
            builder.Property(t => t.Created).HasColumnName("Created");
            builder.Property(t => t.CreatedBy).HasColumnName("CreatedBy");
            builder.Property(t => t.Modified).HasColumnName("Modified");
            builder.Property(t => t.ModifiedBy).HasColumnName("ModifiedBy");
            builder.Property(t => t.Status).HasColumnName("Status");
            builder.Property(t => t.UserId).HasColumnName("UserId");
            builder.Property(t => t.RoleId).HasColumnName("RoleId");
            builder.Property(t => t.Type).HasColumnName("Type");
        }
    }
}
