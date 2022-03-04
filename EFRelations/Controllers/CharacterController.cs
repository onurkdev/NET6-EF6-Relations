using EFRelations.DTO;
using EFRelations.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace EFRelations.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CharacterController : ControllerBase
    {
        private readonly DataContext _context;

        public CharacterController(DataContext context)
        {
            this._context = context;
        }
        [HttpGet]
        public async Task<ActionResult<List<Character>>> Get(int userId)
        {
            var characters = await _context.Characters.Where(c => c.UserId == userId).Include(c=>c.Weapon).ToListAsync();
                return Ok(characters);
        }
        [HttpPost]
        public async Task<ActionResult<List<Character>>> Create(CharacterCreateDTO request)
        {
            var user = await _context.Users.FindAsync(request.UserId);
            if(user == null)
                return NotFound();
            var newCharacter = new Character {
                Name = request.Name,
                RpgClass = request.RpgClass,
                User = user,
            };
            _context.Characters.Add(newCharacter);
            await _context.SaveChangesAsync();
            return await Get(newCharacter.UserId);
        }
    }
}
