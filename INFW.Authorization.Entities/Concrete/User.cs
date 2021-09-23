using INFW.Core.Entities;

namespace INFW.Authorization.Entities.Concrete
{
    public class User : EntityBase
    {
        public virtual string FirstName { get; set; }
        public virtual string LastName { get; set; }
        public virtual string UserName { get; set; }
        public virtual string EmailAddress { get; set; }
        public virtual string PasswordHash { get; set; }
        public virtual int Type { get; set; }
    }
}
