using makersmatch_server.Authentication;
using makersmatch_server.Authentication.Models;
using makersmatch_server.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace makersmatch_server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProblemController : ControllerBase
    {
        [HttpPost]
        [Authorize(Roles = UserRoles.ProblemOwner)]
        [Route("create")]
        public async Task<IActionResult> Create([FromBody] Problem model)
        {
            return Ok();
        }

        [HttpGet]
        [Authorize]
        [Route("get")]
        public async Task<IActionResult> Get(int id)
        {
            return Ok();
        }
    }
}
