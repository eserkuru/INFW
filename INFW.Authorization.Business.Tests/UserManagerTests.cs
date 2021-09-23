using INFW.Authorization.Business.Abstract;
using INFW.Authorization.Business.Concrete.Managers;
using INFW.Authorization.Business.Tests.Moq;
using INFW.Authorization.DataAccess.Abstract;
using Moq;
using System.Linq;
using Xunit;

namespace INFW.Authorization.Business.Tests
{
    public class UserManagerTests
    {
        private readonly Mock<IUserDal> _mockUserDal;
        public UserManagerTests()
        {
            IMockDatabase mockDatabase = new MockDatabase();
            _mockUserDal = new Mock<IUserDal>();
            _mockUserDal.Setup(m => m.GetList(null)).Returns(mockDatabase.Users);
        }

        [Fact]
        public void All_users_can_be_listed()
        {
            IUserService userService = new UserManager(_mockUserDal.Object);
            var result = userService.GetAll().Data;
            Assert.Equal(2, result.Count);
        }

        [Fact]
        public void All_users_can_be_listed_with_the_parameter()
        {
            IUserService userService = new UserManager(_mockUserDal.Object);
            var result = userService.GetAll().Data.Where(u => u.FirstName == "Unit" && u.LastName.Contains("Test")).ToList();
            Assert.Equal(2, result.Count);
        }

        //TODO: Kontrol edilmelidir.
        //[Fact]
        //public void The_roles_of_the_user_can_be_listed()
        //{
        //    IUserService userService = new UserManager(_mockUserDal.Object);
        //    var result = userService.GetUserRoles(new System.Guid("ECD35080-0F25-16C6-0FAA-16789359A161")).Data;
        //    Assert.Equal(2, result.Count);
        //}
    }
}
