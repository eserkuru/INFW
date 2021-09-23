using INFW.Authorization.Entities.Concrete;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace INFW.Authorization.DataAccess.Concrete.EntityFrameworkCore.Mappings
{
    public class UserMap : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
            builder.ToTable(@"Users");
            builder.HasKey(t => t.Id);
            builder.Property(t => t.Created).HasColumnName("Created");
            builder.Property(t => t.CreatedBy).HasColumnName("CreatedBy");
            builder.Property(t => t.Modified).HasColumnName("Modified");
            builder.Property(t => t.ModifiedBy).HasColumnName("ModifiedBy");
            builder.Property(t => t.Status).HasColumnName("Status");
            builder.Property(t => t.EmailAddress).HasColumnName("EmailAddress");
            builder.Property(t => t.FirstName).HasColumnName("FirstName");
            builder.Property(t => t.LastName).HasColumnName("LastName");
            builder.Property(t => t.UserName).HasColumnName("UserName");
            builder.Property(t => t.PasswordHash).HasColumnName("PasswordHash");
            builder.Property(t => t.Type).HasColumnName("Type");
        }
    }
}
