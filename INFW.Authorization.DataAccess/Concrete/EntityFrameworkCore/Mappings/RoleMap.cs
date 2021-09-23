using INFW.Authorization.Entities.Concrete;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace INFW.Authorization.DataAccess.Concrete.EntityFrameworkCore.Mappings
{
    public class RoleMap : IEntityTypeConfiguration<Role>
    {
        public void Configure(EntityTypeBuilder<Role> builder)
        {
            builder.ToTable(@"Roles");
            builder.HasKey(t => t.Id);
            builder.Property(t => t.Created).HasColumnName("Created");
            builder.Property(t => t.CreatedBy).HasColumnName("CreatedBy");
            builder.Property(t => t.Modified).HasColumnName("Modified");
            builder.Property(t => t.ModifiedBy).HasColumnName("ModifiedBy");
            builder.Property(t => t.Status).HasColumnName("Status");
            builder.Property(t => t.Name).HasColumnName("Name");
            builder.Property(t => t.Type).HasColumnName("Type");
        }
    }
}
