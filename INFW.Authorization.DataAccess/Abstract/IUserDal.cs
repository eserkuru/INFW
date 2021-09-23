using INFW.Authorization.Entities.Concrete;
using INFW.Authorization.Entities.DTOs;
using INFW.Core.DataAccess;
using System;
using System.Collections.Generic;

namespace INFW.Authorization.DataAccess.Abstract
{
    public interface IUserDal : IEntityRepository<User>
    {
    }
}
