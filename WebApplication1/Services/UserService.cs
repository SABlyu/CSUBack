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
        }

        public User AddUser(User user)
        {
            _users.Add(user);
            return user;
        }


        private static List<User> _users = new List<User>();
        private readonly DatabaseContext _db;
    }
}
