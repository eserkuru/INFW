using INFW.Authorization.DataAccess.Abstract;
using INFW.Authorization.DataAccess.Concrete.EntityFrameworkCore.Dals;
using System;
using Xunit;

namespace INFW.Authorization.DataAccess.Tests.EntityFrameworkCoreTests
{
    public class EfRoleTests
    {
        [Fact]
        public void All_roles_can_be_listed()
        {
            IRoleDal roleDal = new EfRoleDal();
            var result = roleDal.GetList();

            Assert.Equal(2, result.Count);
        }

        [Fact]
        public void All_roles_can_be_listed_with_the_parameter()
        {
            IRoleDal roleDal = new EfRoleDal();
            var result = roleDal.GetList(r => r.Name.Contains("Unit Test"));

            Assert.Equal(2, result.Count);
        }

        [Fact]
        public void The_roles_of_the_user_can_be_listed()
        {
            IRoleDal roleDal = new EfRoleDal();

            var result = roleDal.GetRolesByUserId(new Guid("ECD35080-0F25-16C6-0FAA-16789359A161"));

            Assert.Equal(2, result.Count);
        }
    }
}
