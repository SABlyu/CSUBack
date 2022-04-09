using Microsoft.EntityFrameworkCore;
using WebApplication1.Contexts;
using WebApplication1.Models;

namespace WebApplication1.Services
{
    public class UserService
    {
        public UserService(DatabaseContext db)
        {
            _db = db;
        }

        public Task<List<User>> GetUsers()
        {
            return _db.Users.ToListAsync();
        }

        public Task<User> GetUser(int id)
        {
            return _db.Users
                .Where(u => u.Id == id)
                .FirstOrDefaultAsync();
            // awesome1password!
        }

        public async Task<User> AddUser(User user)
        {
            await _db.Users.AddAsync(user);
            await _db.SaveChangesAsync();

            return await _db.Users.FindAsync(user.Id);
        }


        private readonly DatabaseContext _db;
    }
}
