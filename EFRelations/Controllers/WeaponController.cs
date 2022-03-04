using EFRelations.DTO;
using EFRelations.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace EFRelations.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class WeaponController : ControllerBase
    {
        private readonly DataContext _context;

        public WeaponController(DataContext context)
        {
            this._context = context;
        }
        [HttpGet]
        public async Task<ActionResult<List<Weapon>>> Get(int characterId)
        {
            var weapons = await _context.Weapons.Where(w=>w.CharacterId == characterId).ToListAsync();
            return Ok(weapons);
        }

        [HttpPost]
        public async Task<ActionResult<List<Weapon>>> Create(WeaponCreateDTO request)
        {
            var character = await _context.Characters.FindAsync(request.CharacterId);
            if (character == null)
                return NotFound("Character is Not found");


            var newWeapon = new Weapon  
            {
                CharacterId = request.CharacterId,
                Name = request.Name,
                Damage = request.Damage,
            };
            _context.Weapons.Add(newWeapon);
            await _context.SaveChangesAsync();
            return await Get(newWeapon.CharacterId);
        }

    }
}
