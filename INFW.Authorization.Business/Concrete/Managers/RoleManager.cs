using INFW.Authorization.Business.Contants;
using INFW.Authorization.DataAccess.Abstract;
using INFW.Authorization.Entities.Concrete;
using INFW.Core.Utilities.Results;
using System;
using System.Collections.Generic;
using System.Linq;

namespace INFW.Authorization.Business.Concrete.Managers
{
    public class RoleManager : IRoleService
    {
        private readonly IRoleDal _roleDal;
        private readonly IUserRoleDal _userRoleDal;

        public RoleManager(IRoleDal roleDal, IUserRoleDal userRoleDal)
        {
            _roleDal = roleDal;
            _userRoleDal = userRoleDal;
        }

        public IResult Add(Role role)
        {
            _roleDal.Add(role);
            return new SuccessResult(Messages.RoleAdded);
        }

        public IResult AddRoleForUser(Guid roleId, Guid userId)
        {
            //TODO: Dummy veridir. EntityBase'de default değerler atanacaktır.
            var userRole = new UserRole 
            {
                Created = "Apr  4 2021  6:43PM",
                CreatedBy = "5246E7DE-0592-44F0-B821-065749647F91",
                Modified = "Apr  4 2021  6:43PM",
                ModifiedBy = "5246E7DE-0592-44F0-B821-065749647F91",
                Status = 0,
                UserId = userId,
                RoleId = roleId,
                Type = 0
            };
            _userRoleDal.Add(userRole);
            return new SuccessResult(Messages.RoleAdded);
        }

        public IResult Delete(Role role)
        {
            _roleDal.Delete(role);
            return new SuccessResult(Messages.RoleDeleted);
        }

        public IDataResult<List<Role>> GetAll()
        {
            var roles = _roleDal.GetList().ToList();
            return new SuccessDataResult<List<Role>>(roles);
        }

        public IDataResult<Role> GetById(Guid id)
        {
            var role = _roleDal.Get(r => r.Id == id);
            return new SuccessDataResult<Role>(role);
        }
        public IDataResult<List<Role>> GetRolesByUserId(Guid userId)
        {
            var userRoles = _roleDal.GetRolesByUserId(userId);
            return new SuccessDataResult<List<Role>>(userRoles);
        }

        public IResult Update(Role role)
        {
            _roleDal.Update(role);
            return new SuccessResult(Messages.RoleUpdated);
        }
    }
}
