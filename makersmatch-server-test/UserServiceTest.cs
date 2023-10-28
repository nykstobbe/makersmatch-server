using makersmatch_server.Authentication;
using makersmatch_server.Services;
using Microsoft.AspNetCore.Identity;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace makersmatch_server_test
{
    public class UserServiceTest
    {
        [Fact]
        public async Task GetUserNameTest()
        {
            // arrange
            var userManagerMock = new Mock<UserManager<ApplicationUser>>(Mock.Of<IUserStore<ApplicationUser>>(), null, null, null, null, null, null, null, null);
            userManagerMock
                .Setup(userManager => userManager.FindByIdAsync(It.IsAny<string>()))
                .Returns(Task.FromResult<ApplicationUser>(new ApplicationUser
                {
                    UserName = "TestUserName",
                }));

            UserService userService = new UserService(userManagerMock.Object);

            // act
            var username = await userService.GetUserName("");

            // assert
            Assert.Equal("TestUserName", username);
        }
    }
}
