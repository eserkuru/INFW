using INFW.Authorization.Business.Abstract;
using INFW.Authorization.Business.Contants;
using INFW.Authorization.DataAccess.Abstract;
using INFW.Authorization.Entities.Concrete;
using INFW.Core.Utilities.Results;
using System;
using System.Collections.Generic;
using System.Linq;

namespace INFW.Authorization.Business.Concrete.Managers
{
    public class UserManager : IUserService
    {
        private readonly IUserDal _userDal;

        public UserManager(IUserDal userDal)
        {
            _userDal = userDal;
        }

        public IResult Add(User user)
        {
            _userDal.Add(user);
            return new SuccessResult(Messages.UserAdded);
        }

        public IResult Delete(User user)
        {
            _userDal.Delete(user);
            return new SuccessResult(Messages.UserDeleted);
        }

        public IDataResult<List<User>> GetAll()
        {
            var users = _userDal.GetList().ToList();
            return new SuccessDataResult<List<User>>(users);
        }

        public IDataResult<User> GetById(Guid id)
        {
            var user = _userDal.Get(u => u.Id == id);
            return new SuccessDataResult<User>(user);
        }

        public IResult Update(User user)
        {
            _userDal.Update(user);
            return new SuccessResult(Messages.UserUpdated);
        }
    }
}
