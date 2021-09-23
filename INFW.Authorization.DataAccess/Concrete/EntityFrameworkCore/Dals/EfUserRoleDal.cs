using INFW.Authorization.DataAccess.Abstract;
using INFW.Authorization.DataAccess.Concrete.EntityFrameworkCore.Contexts;
using INFW.Authorization.Entities.Concrete;
using INFW.Core.DataAccess.EntityFrameworkCore;

namespace INFW.Authorization.DataAccess.Concrete.EntityFrameworkCore.Dals
{
    public class EfUserRoleDal : EfEntityReporsitoryBase<UserRole,AuthorizationContext>, IUserRoleDal
    {
    }
}
