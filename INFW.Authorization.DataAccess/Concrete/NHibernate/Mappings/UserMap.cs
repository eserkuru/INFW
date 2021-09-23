using FluentNHibernate.Mapping;
using INFW.Authorization.Entities.Concrete;

namespace INFW.Authorization.DataAccess.Concrete.NHibernate.Mappings
{
    public class UserMap : ClassMap<User>
    {
        public UserMap()
        {
            Table(@"[Users]");
            LazyLoad();
            Id(u => u.Id).Column("[Id]");
            Map(u => u.Created).Column("[Created]");
            Map(u => u.CreatedBy).Column("[CreatedBy]");
            Map(u => u.Modified).Column("[Modified]");
            Map(u => u.ModifiedBy).Column("[ModifiedBy]");
            Map(u => u.Status).Column("[Status]");
            Map(u => u.EmailAddress).Column("[EmailAddress]");
            Map(u => u.FirstName).Column("[FirstName]");
            Map(u => u.LastName).Column("[LastName]");
            Map(u => u.UserName).Column("[UserName]");
            Map(u => u.PasswordHash).Column("[PasswordHash]");
            Map(u => u.Type).Column("[Type]");
        }
    }
}
