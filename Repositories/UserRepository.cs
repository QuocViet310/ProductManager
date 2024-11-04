using System.Collections.Generic;
using System.Linq;
using BusinessObjects.Models;

namespace Repositories
{
    public class UserRepository : IUserRepository
    {
        private readonly ProductManagementDbContext _context;

        public UserRepository(ProductManagementDbContext context)
        {
            _context = context;
        }

        public List<User> GetAllUsers()
        {
            return _context.Users.ToList();
        }

        public void UpdateUser(User user)
        {
            _context.Users.Update(user);
            _context.SaveChanges();
        }

        public void DeleteUser(int userId)
        {
            var user = _context.Users.Find(userId);
            if (user != null)
            {
                _context.Users.Remove(user);
                _context.SaveChanges();
            }
        }

        public User GetUserByUsername(string username)
        {
            return _context.Users.FirstOrDefault(u => u.Username == username);
        }

        public void AddUser(User newUser)
        {
            _context.Users.Add(newUser);
            _context.SaveChanges();
        }

        public User GetUserByUsernameAndPassword(string username, string password)
        {
            return _context.Users
                .FirstOrDefault(u => u.Username == username && u.Password == password && u.IsActive);
        }
    }
}
