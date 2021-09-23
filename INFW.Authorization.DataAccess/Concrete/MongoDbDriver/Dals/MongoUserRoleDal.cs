using INFW.Authorization.DataAccess.Abstract;
using INFW.Authorization.DataAccess.Concrete.MongoDbDriver.Clients;
using INFW.Authorization.Entities.Concrete;
using INFW.Core.DataAccess.MongoDbDriver;

namespace INFW.Authorization.DataAccess.Concrete.MongoDbDriver.Dals
{
    public class MongoUserRoleDal : MongoEntityRepositoryBase<UserRole, AuthorizationClient>, IUserRoleDal
    {
    }
}
