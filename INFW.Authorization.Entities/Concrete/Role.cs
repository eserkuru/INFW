using INFW.Core.Entities;

namespace INFW.Authorization.Entities.Concrete
{
    public class Role : EntityBase
    {
        public virtual string Name { get; set; }
        public virtual int Type { get; set; }
    }
}
