using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Library.Models;

namespace Library.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ActionsController : ControllerBase
    {
        private readonly LibraryContext _context;

        public ActionsController(LibraryContext context)
        {
            _context = context;
        }

        // GET: api/Actions
        [HttpGet]
        public async Task<ActionResult> GetActions()
        {
            var actions = await _context.Actions.ToListAsync();
            return Ok(actions);
        }
    }
}

