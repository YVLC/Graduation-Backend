using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Test.API.Data;

namespace Test.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]


    public class SuperHeroController : ControllerBase
    {

        private readonly DataContext _context;
        public SuperHeroController(DataContext context)
        {
            _context= context;
        }

        [HttpGet]
        public async Task<ActionResult<List<SuperHero>>> Get()
        {
            return Ok(await _context.SuperHeroes.ToListAsync());
        }
        [HttpGet("{id}")]
        public async Task<ActionResult<SuperHero>> Get(int id)
        {
            var hero = _context.SuperHeroes.FindAsync(id);
            if (hero.Result == null)
                return BadRequest("Hero Not Found");
            return Ok(hero.Result);
        }
        [HttpPut]
        public async Task<ActionResult<SuperHero>> UpdateHero(SuperHero request)
        {
            var dbhero = _context.SuperHeroes.FindAsync(request.Id);
            if (dbhero.Result == null)
                return BadRequest("Hero Not Found");
            
            dbhero.Result.FirstName = request.FirstName;
            dbhero.Result.Name = request.Name;
            dbhero.Result.LastName = request.LastName;
            dbhero.Result.Place = request.Place;

            await _context.SaveChangesAsync();
            
            return Ok(await _context.SuperHeroes.ToArrayAsync());

        }

        [HttpPost]
        public async Task<ActionResult<List<SuperHero>>> AddHero(SuperHero hero)
        {
            _context.SuperHeroes.Add(hero);
            await _context.SaveChangesAsync();
            return Ok(await _context.SuperHeroes.ToListAsync());
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<List<SuperHero>>> Delete(int id)
        {
            var hero = _context.SuperHeroes.FindAsync(id);
            if (hero.Result == null)
                return BadRequest("Hero Not Found");
            _context.SuperHeroes.Remove(hero.Result);
            await _context.SaveChangesAsync();
            return Ok(await _context.SuperHeroes.ToListAsync());
        }
    }
}
