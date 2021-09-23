using INFW.Authorization.Entities.Concrete;
using INFW.Core.DataAccess;

namespace INFW.Authorization.DataAccess.Abstract
{
    public interface IUserRoleDal : IEntityRepository<UserRole>
    {
        // Custom Methods.
    }
}
