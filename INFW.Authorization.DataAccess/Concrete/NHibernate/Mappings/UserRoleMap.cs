using FluentNHibernate.Mapping;
using INFW.Authorization.Entities.Concrete;

namespace INFW.Authorization.DataAccess.Concrete.NHibernate.Mappings
{
    public class UserRoleMap : ClassMap<UserRole>
    {
        public UserRoleMap()
        {
            Table(@"[UserRoles]");
            LazyLoad();
            Id(t => t.Id).Column("[Id]");
            Map(t => t.Created).Column("[Created]");
            Map(t => t.CreatedBy).Column("[CreatedBy]");
            Map(t => t.Modified).Column("[Modified]");
            Map(t => t.ModifiedBy).Column("[ModifiedBy]");
            Map(t => t.Status).Column("[Status]");
            Map(t => t.UserId).Column("[UserId]");
            Map(t => t.RoleId).Column("[RoleId]");
            Map(t => t.Type).Column("[Type]");
        }
    }
}
