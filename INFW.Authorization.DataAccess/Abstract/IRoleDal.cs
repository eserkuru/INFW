using INFW.Authorization.Entities.Concrete;
using INFW.Core.DataAccess;
using System;
using System.Collections.Generic;

namespace INFW.Authorization.DataAccess.Abstract
{
    public interface IRoleDal : IEntityRepository<Role>
    {
        List<Role> GetRolesByUserId(Guid userId);
    }
}
