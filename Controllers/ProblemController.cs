using makersmatch_server.Authentication;
using makersmatch_server.Authentication.Models;
using makersmatch_server.Data;
using makersmatch_server.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace makersmatch_server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProblemController : ControllerBase
    {
        private readonly MakersMatchContext _context;

        public ProblemController(MakersMatchContext context)
        {
            _context = context;
        }

        [HttpPost]
        [Authorize(Roles = UserRoles.ProblemOwner)]
        [Route("create")]
        public async Task<IActionResult> Create([FromBody] Problem model)
        {
            if(!ModelState.IsValid)
                return BadRequest(ModelState);

            model.UserId = User.FindFirst(ClaimTypes.NameIdentifier)?.Value;

            _context.Problems.Add(model);
            _context.SaveChanges();

            return Ok();
        }

        [HttpGet]
        [Authorize]
        [Route("get")]
        public async Task<IActionResult> Get(int id)
        {
            Problem? problem = _context.Problems.Find(id);
            if (problem == null)
                return NotFound();

            return Ok(problem);            
        }

        [HttpGet]
        [Authorize]
        [Route("get-all")]
        public async Task<IActionResult> GetAll()
        {
            List<Problem> problems = _context.Problems.ToList();

            return Ok(problems);
        }

        [HttpGet]
        [Authorize(Roles = UserRoles.ProblemOwner)]
        [Route("get-user-problems")]
        public async Task<IActionResult> GetUserProblems()
        {
            string? userId = User.FindFirst(ClaimTypes.NameIdentifier)?.Value;

            if (string.IsNullOrEmpty(userId))
                return BadRequest();

            List<Problem> problems = _context.Problems.Where(p => p.UserId == userId).ToList();

            return Ok(problems);
        }
    }
}
