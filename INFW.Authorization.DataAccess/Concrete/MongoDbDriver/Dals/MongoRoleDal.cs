using INFW.Authorization.DataAccess.Abstract;
using INFW.Authorization.DataAccess.Concrete.MongoDbDriver.Clients;
using INFW.Authorization.Entities.Concrete;
using INFW.Core.DataAccess.MongoDbDriver;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;

namespace INFW.Authorization.DataAccess.Concrete.MongoDbDriver.Dals
{
    public class MongoRoleDal : MongoEntityRepositoryBase<Role, AuthorizationClient>, IRoleDal
    {
        public List<Role> GetRolesByUserId(Guid userId)
        {
            using (var client = new AuthorizationClient())
            {
                var result = from u in client.Database.GetCollection<User>("Users").Find(u => true).ToList().Where(u => u.Id == userId)
                             join ur in client.Database.GetCollection<UserRole>("UserRoles").Find(ur => true).ToList() on u.Id equals ur.UserId
                             join r in client.Database.GetCollection<Role>("Roles").Find(r => true).ToList() on ur.RoleId equals r.Id
                             select r;

                return result.ToList();
            }
        }
    }
}
