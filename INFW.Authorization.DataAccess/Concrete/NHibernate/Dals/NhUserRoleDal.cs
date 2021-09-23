using INFW.Authorization.DataAccess.Abstract;
using INFW.Authorization.Entities.Concrete;
using INFW.Core.DataAccess.NHibernate;

namespace INFW.Authorization.DataAccess.Concrete.NHibernate.Dals
{
    public class NhUserRoleDal : NhEntityRepositortyBase<UserRole>, IUserRoleDal
    {
        public NhUserRoleDal(NHibernateHelper nHibernateHelper) : base(nHibernateHelper)
        {
        }
    }
}
