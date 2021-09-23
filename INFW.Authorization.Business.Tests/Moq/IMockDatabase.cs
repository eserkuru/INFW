using INFW.Authorization.Entities.Concrete;
using INFW.Authorization.Entities.DTOs;
using System.Collections.Generic;

namespace INFW.Authorization.Business.Tests.Moq
{
    public interface IMockDatabase
    {
        List<User> Users { get; set; }
        List<UserRole> UserRoles { get; set; }
        List<Role> Roles { get; set; }
        List<UserRoleDto> UserRoleDtos { get; set; }
    }
}
