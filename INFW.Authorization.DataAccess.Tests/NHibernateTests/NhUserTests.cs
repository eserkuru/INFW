using INFW.Authorization.DataAccess.Abstract;
using INFW.Authorization.DataAccess.Concrete.NHibernate.Dals;
using INFW.Authorization.DataAccess.Concrete.NHibernate.Helpers;
using System;
using Xunit;

namespace INFW.Authorization.DataAccess.Tests.NHibernateTests
{
    public class NhUserTests
    {
        [Fact]
        public void All_users_can_be_listed()
        {
            IUserDal userDal = new NhUserDal(new SqlServerHelper());
            var result = userDal.GetList();

            Assert.Equal(2, result.Count);
        }

        [Fact]
        public void All_users_can_be_listed_with_the_parameter()
        {
            IUserDal userDal = new NhUserDal(new SqlServerHelper());
            var result = userDal.GetList(u => u.FirstName == "Unit" && u.LastName.Contains("Test"));

            Assert.Equal(2, result.Count);
        }
    }
}
