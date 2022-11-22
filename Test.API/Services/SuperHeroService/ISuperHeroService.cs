namespace Test.API.Services.SuperHeroService
{
    public interface ISuperHeroService
    {
        Task<List<SuperHero>> GetAllSuperHeroes();
        Task<SuperHero> Get(int id);
        Task<List<SuperHero>> AddHero(SuperHero hero);
        Task<List<SuperHero>> UpdateHero(SuperHero request);
        Task<List<SuperHero>>? DeleteHero(int id);

    }
}
