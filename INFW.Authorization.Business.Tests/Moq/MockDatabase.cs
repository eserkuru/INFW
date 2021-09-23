using INFW.Authorization.Entities.Concrete;
using INFW.Authorization.Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;

namespace INFW.Authorization.Business.Tests.Moq
{
    public class MockDatabase : IMockDatabase
    {
        public List<User> Users { get => UsersCollection(); set => Users = value; }
        public List<UserRole> UserRoles { get => UserRolesCollection(); set => UserRoles = value; }
        public List<Role> Roles { get => RolesCollection(); set => Roles = value; }
        public List<UserRoleDto> UserRoleDtos { get => UserRolesView(); set => UserRoleDtos = value; }

        #region Collections
        private List<User> UsersCollection()
        {
            return new List<User>
            {
                new User{
                    Id=new Guid("ECD35080-0F25-16C6-0FAA-16789359A161"),
                    Created = DateTime.Now.ToString(),
                    CreatedBy = "5246E7DE-0592-44F0-B821-065749647F91",
                    Modified = DateTime.Now.ToString(),
                    ModifiedBy = "5246E7DE-0592-44F0-B821-065749647F91",
                    Status = 0,
                    FirstName = "Unit",
                    LastName = "Test1",
                    UserName = "unit.test1",
                    EmailAddress = "unit.test1@infoline-tr.com",
                    PasswordHash = "14e1b600b1fd579f47433b88e8d85291",
                    Type = 0
                },
                new User{
                    Id=new Guid("FE20D55E-0D22-329F-0147-BDAD80738DAA"),
                    Created = DateTime.Now.ToString(),
                    CreatedBy = "5246E7DE-0592-44F0-B821-065749647F91",
                    Modified = DateTime.Now.ToString(),
                    ModifiedBy = "5246E7DE-0592-44F0-B821-065749647F91",
                    Status = 0,
                    FirstName = "Unit",
                    LastName = "Test2",
                    UserName = "unit.test2",
                    EmailAddress = "unit.test2@infoline-tr.com",
                    PasswordHash = "14e1b600b1fd579f47433b88e8d85291",
                    Type = 0
                }
            };
        }

        private List<UserRole> UserRolesCollection()
        {
            return new List<UserRole>
            {
                new UserRole
                {
                    Id = new Guid("BAE6449E-C984-49B7-85B8-966989BB7B6E"),
                    Created = DateTime.Now.ToString(),
                    CreatedBy = "5246E7DE-0592-44F0-B821-065749647F91",
                    Modified = DateTime.Now.ToString(),
                    ModifiedBy = "5246E7DE-0592-44F0-B821-065749647F91",
                    Status = 0,
                    UserId = new Guid("ECD35080-0F25-16C6-0FAA-16789359A161"),
                    RoleId = new Guid("087DA7AD-5D8A-4ECD-83ED-779B241C98F9"),
                    Type = 1
                },
                new UserRole
                {
                    Id = new Guid("B18EC4B1-73DF-48D9-9607-F5BD95CD9B7B"),
                    Created = DateTime.Now.ToString(),
                    CreatedBy = "5246E7DE-0592-44F0-B821-065749647F91",
                    Modified = DateTime.Now.ToString(),
                    ModifiedBy = "5246E7DE-0592-44F0-B821-065749647F91",
                    Status = 0,
                    UserId = new Guid("ECD35080-0F25-16C6-0FAA-16789359A161"),
                    RoleId = new Guid("10EBB72C-0F8D-4663-9BD5-2119929261ED"),
                    Type = 1
                },
                new UserRole
                {
                    Id = new Guid("F5D7A922-6B61-46F1-A45F-A93A8BC03CE9"),
                    Created = DateTime.Now.ToString(),
                    CreatedBy = "5246E7DE-0592-44F0-B821-065749647F91",
                    Modified = DateTime.Now.ToString(),
                    ModifiedBy = "5246E7DE-0592-44F0-B821-065749647F91",
                    Status = 0,
                    UserId = new Guid("FE20D55E-0D22-329F-0147-BDAD80738DAA"),
                    RoleId = new Guid("087DA7AD-5D8A-4ECD-83ED-779B241C98F9"),
                    Type = 1
                },
                new UserRole
                {
                    Id = new Guid("73DC8243-A65E-4945-AFD5-22C66E00E75C"),
                    Created = DateTime.Now.ToString(),
                    CreatedBy = "5246E7DE-0592-44F0-B821-065749647F91",
                    Modified = DateTime.Now.ToString(),
                    ModifiedBy = "5246E7DE-0592-44F0-B821-065749647F91",
                    Status = 0,
                    UserId = new Guid("FE20D55E-0D22-329F-0147-BDAD80738DAA"),
                    RoleId = new Guid("10EBB72C-0F8D-4663-9BD5-2119929261ED"),
                    Type = 1
                }
            };
        }

        private List<Role> RolesCollection()
        {
            return new List<Role>
            {
                new Role
                {
                    Id = new Guid("087DA7AD-5D8A-4ECD-83ED-779B241C98F9"),
                    Created = DateTime.Now.ToString(),
                    CreatedBy = "5246E7DE-0592-44F0-B821-065749647F91",
                    Modified = DateTime.Now.ToString(),
                    ModifiedBy = "5246E7DE-0592-44F0-B821-065749647F91",
                    Status = 0,
                    Name = "Unit Test 1",
                    Type = 1
                },
                new Role
                {
                    Id = new Guid("10EBB72C-0F8D-4663-9BD5-2119929261ED"),
                    Created = DateTime.Now.ToString(),
                    CreatedBy = "5246E7DE-0592-44F0-B821-065749647F91",
                    Modified = DateTime.Now.ToString(),
                    ModifiedBy = "5246E7DE-0592-44F0-B821-065749647F91",
                    Status = 0,
                    Name = "Unit Test 1",
                    Type = 1
                }
            };
        }
        #endregion

        #region Views
        private List<UserRoleDto> UserRolesView()
        {
            var result = from u in Users
                         join ur in UserRoles on u.Id equals ur.UserId
                         join r in Roles on ur.RoleId equals r.Id
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
        #endregion
    }
}