using INFW.Authorization.DataAccess.Abstract;
using INFW.Authorization.DataAccess.Concrete.EntityFrameworkCore.Contexts;
using INFW.Authorization.Entities.Concrete;
using INFW.Core.DataAccess.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;

namespace INFW.Authorization.DataAccess.Concrete.EntityFrameworkCore.Dals
{
    public class EfRoleDal : EfEntityReporsitoryBase<Role, AuthorizationContext>, IRoleDal
    {
        public List<Role> GetRolesByUserId(Guid userId)
        {
            using (var context = new AuthorizationContext())
            {
                var result = from u in context.Set<User>().Where(u => u.Id == userId)
                             join ur in context.Set<UserRole>() on u.Id equals ur.UserId
                             join r in context.Set<Role>() on ur.RoleId equals r.Id
                             select r;

                return result.ToList();
            }
        }
    }
}
