using EFRelations.DTO;
using EFRelations.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace EFRelations.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SkillsController : ControllerBase
    {
        private readonly DataContext _context;

        public SkillsController(DataContext context)
        {
            this._context = context;
        }

        [HttpGet]
        public async Task<ActionResult<List<Skill>>> Get()
        {
            var skills = await _context.Skills.ToListAsync();
            return Ok(skills);
        }

        [HttpPost]
        public async Task<ActionResult<List<Skill>>> Create(SkillCreateDTO request)
        {
            var newSkill = new Skill
            {
                Damage = request.Damage,
                Name = request.Name,
            };
            _context.Skills.Add(newSkill);
            await _context.SaveChangesAsync();
            return Ok(newSkill);

        }
        [HttpPut]
        public async Task<ActionResult<List<Skill>>> AddSkilltoCharacter(AddSkilltoCharacterDTO request){
            var character = await _context.Characters.Where(c=>c.Id==request.CharacterId).Include(c=>c.Skills).FirstOrDefaultAsync();
            if (character == null)
                return NotFound("Character is Not found");
            var skill = await _context.Skills.FindAsync(request.SkillId);
            if (skill == null)
                return NotFound("Skill is Not found");

            character.Skills.Add(skill);
            await _context.SaveChangesAsync();
            return Ok(character);

        }
    }
}
