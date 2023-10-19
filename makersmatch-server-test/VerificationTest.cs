using makersmatch_server.Authentication;
using makersmatch_server.Controllers;
using makersmatch_server.Data;
using makersmatch_server.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Moq;
using Xunit;

namespace makersmatch_server_test
{
    public class VerificationTest
    {
        [Fact]
        public async Task SuccesTaskAsync()
        {
            
        }

        [Fact]
        public async Task FailTestAsync()
        {
            Assert.Equal(1, 2);
        }
    }
}