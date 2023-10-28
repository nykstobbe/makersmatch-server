using makersmatch_server.Authentication;
using makersmatch_server.Data;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace makersmatch_server.Services
{
    public class UserService : IUserService
    {
        private readonly UserManager<ApplicationUser> _userManager;

        public UserService(UserManager<ApplicationUser> userManager)
        {
            _userManager = userManager;
        }

        public async Task<string> GetUserName(string UserId)
        {
            var user = await _userManager.FindByIdAsync(UserId);
            return user.UserName;
        }
    }
}
