using INFW.Authorization.Entities.Concrete;
using INFW.Core.Utilities.Results;
using System;
using System.Collections.Generic;

namespace INFW.Authorization.Business
{
    public interface IRoleService
    {
        IDataResult<List<Role>> GetAll();
        IDataResult<Role> GetById(Guid id);
        IResult Add(Role role);
        IResult Update(Role role);
        IResult Delete(Role role);
        IResult AddRoleForUser(Guid roleId, Guid userId);
        IDataResult<List<Role>> GetRolesByUserId(Guid userId);
    }
}