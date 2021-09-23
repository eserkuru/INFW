using INFW.Authorization.DataAccess.Abstract;
using INFW.Authorization.Entities.Concrete;
using INFW.Core.DataAccess.NHibernate;

namespace INFW.Authorization.DataAccess.Concrete.NHibernate.Dals
{
    public class NhUserDal : NhEntityRepositortyBase<User>, IUserDal
    {
        public NhUserDal(NHibernateHelper nHibernateHelper) : base(nHibernateHelper)
        {
        }
    }
}
