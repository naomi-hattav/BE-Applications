using Moq;
using UsersApplication.Controllers;
using UsersApplication.Domain;
using UsersApplication.Services;
using Xunit;

namespace UsersApplication.tests
{
    public class UsersControllerTests
    {
        private readonly Mock<IUserService> _userServiceMock;
        private readonly UsersController _usersController;
        public UsersControllerTests()
        {
          this._userServiceMock = new Mock<IUserService>();
          this._usersController = new UsersController(_userServiceMock.Object);
        }

        [Fact]
        public void GetAll_Success()
        {
            var user = new User() { Id = 1, Name = "aa", Email = "aa@aa.com" };
            this._userServiceMock.Setup(mock => mock.GetAll()).Returns(new List<User>() { user });

            this._usersController.GetAll();

            this._userServiceMock.Verify(mock => mock.GetAll(), Times.Once());
        }
    }
}
