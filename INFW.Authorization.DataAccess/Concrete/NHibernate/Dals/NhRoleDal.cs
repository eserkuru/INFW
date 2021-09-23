using INFW.Authorization.DataAccess.Abstract;
using INFW.Authorization.Entities.Concrete;
using INFW.Core.DataAccess.NHibernate;
using System;
using System.Collections.Generic;
using System.Linq;

namespace INFW.Authorization.DataAccess.Concrete.NHibernate.Dals
{
    public class NhRoleDal : NhEntityRepositortyBase<Role>, IRoleDal
    {
        private readonly NHibernateHelper _nHibernateHelper;

        public NhRoleDal(NHibernateHelper nHibernateHelper) : base(nHibernateHelper)
        {
            _nHibernateHelper = nHibernateHelper;
        }

        public List<Role> GetRolesByUserId(Guid userId)
        {
            using (var session = _nHibernateHelper.OpenSession())
            {
                var result = from u in session.Query<User>().Where(u => u.Id == userId).ToList()
                             join ur in session.Query<UserRole>() on u.Id equals ur.UserId
                             join r in session.Query<Role>() on ur.RoleId equals r.Id
                             select r;

                return result.ToList();
            }
        }
    }
}
