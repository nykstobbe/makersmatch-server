using makersmatch_server.Authentication;
using makersmatch_server.Controllers;
using makersmatch_server.Data;
using makersmatch_server.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Moq;

namespace makersmatch_server_test
{
    public class VerificationTest
    {
        [Fact]
        public async Task Test1Async()
        {
            // arrange
            var mock = new Mock<MakersMatchContext>();
            var mockSet = new Mock<DbSet<Problem>>();
            mock.Setup(x => x.Set<Problem>())
                .Returns(mockSet.Object);

            var controller = new ProblemController(mock.Object);

            // act
            var response = await controller.Get(-1);
            
            // assert
            Assert.IsType<NotFoundResult>(response);
        }
    }
}