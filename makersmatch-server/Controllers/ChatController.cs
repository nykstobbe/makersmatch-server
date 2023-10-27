using makersmatch_server.Authentication;
using makersmatch_server.Data;
using makersmatch_server.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Security.Claims;

namespace makersmatch_server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ChatController : ControllerBase
    {
        private readonly MakersMatchContext _context;

        public ChatController(MakersMatchContext context) {
            _context = context;
        }

        [HttpGet]
        [Route("start-new-chat/{userId}")]
        public async Task<IActionResult> StartNewChat(string userId)
        {
            var chat = new Chat();

            var thisUser = User.FindFirst(ClaimTypes.NameIdentifier)?.Value;

            chat.User1 = new SimpleUser { Id = thisUser, Name = "" };
            chat.User2 = new SimpleUser { Id = userId, Name = "" };

            _context.Chats.Add(chat);
            _context.SaveChanges();

            return Ok(chat.Id);
        }
    }
}
