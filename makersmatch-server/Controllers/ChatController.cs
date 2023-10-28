using makersmatch_server.Authentication;
using makersmatch_server.Data;
using makersmatch_server.Hubs;
using makersmatch_server.Models;
using makersmatch_server.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.SignalR;
using Microsoft.EntityFrameworkCore;
using System.Security.Claims;

namespace makersmatch_server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ChatController : ControllerBase
    {
        private readonly MakersMatchContext _context;
        private readonly IHubContext<ChatHub> _hubContext;
        private readonly IUserService _userService;

        public ChatController(MakersMatchContext context, IHubContext<ChatHub> hubContext, IUserService userService) {
            _context = context;
            _hubContext = hubContext;
            _userService = userService;
        }

        [HttpGet]
        [Route("start-new-chat/{userId}")]
        public async Task<IActionResult> StartNewChat(string userId)
        {
            var chat = new Chat();

            var thisUser = User.FindFirst(ClaimTypes.NameIdentifier)?.Value;

            chat.User1ID = thisUser;
            chat.User2ID = userId;

            _context.Chats.Add(chat);
            _context.SaveChanges();

            return Ok(chat.Id);
        }

        [HttpGet]
        [Authorize]
        [Route("get-messages/{chatId}")]
        public async Task<IActionResult> GetMessages(int chatId)
        {
            var chat = _context.Chats.Find(chatId);

            if (chat == null)
                return BadRequest();

            chat.ChatMessages = _context.ChatMessages.Where(cm => cm.Chat.Id == chat.Id).ToList();

            foreach (ChatMessage cm in chat.ChatMessages)
            {
                cm.SenderID = await _userService.GetUserName(cm.SenderID);
            }

            return Ok(chat);
        }

        [HttpPost]
        [Authorize]
        [Route("send-message/{chatId}")]
        public async Task<IActionResult> SendMessage(int chatId, [FromBody] string message)
        {
            var chat = _context.Chats.Find(chatId);
            var thisUserId = User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
            
            if (chat is null || thisUserId is null)
                return BadRequest();

            var chatMessage = new ChatMessage {
                Message = message,
                SenderID = thisUserId,
                Chat = chat
            };

            _context.ChatMessages.Add(chatMessage);
            _context.SaveChanges();

            await _hubContext.Clients.All.SendAsync("receiveMessage", await _userService.GetUserName(thisUserId), message);

            return Ok();
        }
    }
}
