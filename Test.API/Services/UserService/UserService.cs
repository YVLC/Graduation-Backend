using Microsoft.EntityFrameworkCore;
using Test.API.Data;

namespace Test.API.Services.UserService
{
    public class UserService : IUserService
    {
        private readonly DataContext _context;

        public UserService(DataContext context)
        {
            _context = context;
        }
        public async Task<List<User>> AddUser(User hero)
        {
            _context.Users.Add(hero);
            await _context.SaveChangesAsync();
            return await _context.Users.ToListAsync();
        }

        public async Task<List<User>> DeleteUser(int id)
        {
            var user = await _context.Users.FindAsync(id);
            if (user == null)
                return null;
            _context.Users.Remove(user);
            await _context.SaveChangesAsync();
            var user2 = await _context.Users.ToListAsync();
            return user2;
        }

        public async Task<User> GetUser(int id)
        {
            var user = await _context.Users.FindAsync(id);
            if (user == null)
                return null;
            return user;
        }

        public async Task<List<User>> UpdateUser(User request)
        {
            var dbuser = await _context.Users.FindAsync(request.Id);
            if (dbuser == null)
                return null;

            dbuser.FirstName = request.FirstName;
            dbuser.Name = request.Name;
            dbuser.LastName = request.LastName;
            dbuser.Place = request.Place;

            await _context.SaveChangesAsync();

            return await _context.Users.ToListAsync();
        }

        public async Task<List<User>> GetAllUsers()
        {
            return await _context.Users.ToListAsync();
        }

        
    }
}
