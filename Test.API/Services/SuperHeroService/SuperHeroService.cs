using Microsoft.EntityFrameworkCore;
using Test.API.Data;

namespace Test.API.Services.SuperHeroService
{
    public class SuperHeroService : ISuperHeroService
    {
        private readonly DataContext _context;

        public SuperHeroService(DataContext context)
        {
            _context = context;
        }
        public async Task<List<SuperHero>> AddHero(SuperHero hero)
        {
            _context.SuperHeroes.Add(hero);
            await _context.SaveChangesAsync();
            return await _context.SuperHeroes.ToListAsync();
        }

        public async Task<List<SuperHero>> DeleteHero(int id)
        {
            var hero = await _context.SuperHeroes.FindAsync(id);
            if (hero == null)
                return null;
            _context.SuperHeroes.Remove(hero);
            await _context.SaveChangesAsync();
            var hero2 = await _context.SuperHeroes.ToListAsync();
            return hero2;
        }

        public async Task<SuperHero> Get(int id)
        {
            var hero = await _context.SuperHeroes.FindAsync(id);
            if (hero == null)
                return null;
            return hero;
        }

        public async Task<List<SuperHero>> UpdateHero(SuperHero request)
        {
            var dbhero = await _context.SuperHeroes.FindAsync(request.Id);
            if (dbhero == null)
                return null;

            dbhero.FirstName = request.FirstName;
            dbhero.Name = request.Name;
            dbhero.LastName = request.LastName;
            dbhero.Place = request.Place;

            await _context.SaveChangesAsync();

            return await _context.SuperHeroes.ToListAsync();
        }

        public async Task<List<SuperHero>> GetAllSuperHeroes()
        {
            return await _context.SuperHeroes.ToListAsync();
        }

        
    }
}
