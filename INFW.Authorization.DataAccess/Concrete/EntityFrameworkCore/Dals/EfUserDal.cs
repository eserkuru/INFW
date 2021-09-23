using INFW.Authorization.DataAccess.Abstract;
using INFW.Authorization.DataAccess.Concrete.EntityFrameworkCore.Contexts;
using INFW.Authorization.Entities.Concrete;
using INFW.Authorization.Entities.DTOs;
using INFW.Core.DataAccess.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;

namespace INFW.Authorization.DataAccess.Concrete.EntityFrameworkCore.Dals
{
    public class EfUserDal : EfEntityReporsitoryBase<User, AuthorizationContext>, IUserDal
    {
        public List<UserRoleDto> GetUserRolesById(Guid id)
        {
            using (var context = new AuthorizationContext())
            {
                var result = from u in context.Set<User>()
                             where u.Id == id
                             join ur in context.Set<UserRole>() on u.Id equals ur.UserId
                             join r in context.Set<Role>() on ur.RoleId equals r.Id
                             select new UserRoleDto
                             {
                                 UserId = u.Id,
                                 FirstName = u.FirstName,
                                 LastName = u.LastName,
                                 UserName = u.UserName,
                                 EmailAddress = u.EmailAddress,
                                 RoleId = r.Id,
                                 RoleName = r.Name
                             };

                return result.ToList();
            }
        }
    }
}
