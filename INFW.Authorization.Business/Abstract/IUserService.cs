using INFW.Authorization.Entities.Concrete;
using INFW.Core.Utilities.Results;
using System;
using System.Collections.Generic;

namespace INFW.Authorization.Business.Abstract
{
    public interface IUserService
    {
        IDataResult<List<User>> GetAll();
        IDataResult<User> GetById(Guid id);
        IResult Add(User user);
        IResult Update(User user);
        IResult Delete(User user);
    }
}
