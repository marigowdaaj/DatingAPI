using DatingAPI.Data;
using DatingAPI.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace DatingAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class UsersController : ControllerBase
    {
        private readonly DataContext _context;

        public UsersController(DataContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<AppUser>>> getUsers()
        {
            var Users =await _context.Users.ToListAsync();

            return Users;
        }

        [HttpGet ("{Id}")]
        public async Task<ActionResult<AppUser>> getUser(int Id)
        {
            return await _context.Users.FindAsync(Id);
           
        }
    }
}
