using DatingAPI.Data;
using DatingAPI.Entities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace DatingAPI.Controllers
{
    [Authorize]

    public class UsersController : ControllerBase
    {
        private readonly DataContext _context;

        public UsersController(DataContext context)
        {
            _context = context;
        }

        [AllowAnonymous]

        [HttpGet]
        public async Task<ActionResult<IEnumerable<AppUser>>> getUsers()
        {
            var users =await _context.Users.ToListAsync();

            return users;
        }

        [HttpGet ("{Id}")]
        public async Task<ActionResult<AppUser>> getUser(int Id)
        {
            return await _context.Users.FindAsync(Id);
           
        }
    }
}
