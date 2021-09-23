using FluentNHibernate.Mapping;
using INFW.Authorization.Entities.Concrete;

namespace INFW.Authorization.DataAccess.Concrete.NHibernate.Mappings
{
    public class RoleMap : ClassMap<Role>
    {
        public RoleMap()
        {
            Table(@"[Roles]");
            LazyLoad();
            Id(t => t.Id).Column("[Id]");
            Map(t => t.Created).Column("[Created]");
            Map(t => t.CreatedBy).Column("[CreatedBy]");
            Map(t => t.Modified).Column("[Modified]");
            Map(t => t.ModifiedBy).Column("[ModifiedBy]");
            Map(t => t.Status).Column("[Status]");
            Map(t => t.Name).Column("[Name]");
            Map(t => t.Type).Column("[Type]");
        }
    }
}
