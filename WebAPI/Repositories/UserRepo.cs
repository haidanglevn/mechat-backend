using Core.Entities;

using Microsoft.EntityFrameworkCore;
using WebAPI.Database;
using WebAPI.Repositories.Interfaces;

namespace WebAPI.Repositories
{
    public class UserRepo : IUserRepo
    {
        private DbSet<User> _users;
        private DatabaseContext _database;
        public UserRepo(DatabaseContext database)
        {
            _database = database;
            _users = database.Users;
        }

        public bool CheckEmail(string email)
        {
            return _users.Any(user => user.Email == email);
        }

        public User CreateNewUser(User user)
        {
            _users.Add(user);
            _database.SaveChanges();
            return user;
        }

        public IEnumerable<User> GetAllUsers(GetAllParams options)
        {
            throw new NotImplementedException();
        }

        public User? GetOneUser(Guid userId)
        {
            return _users.FirstOrDefault(u=> u.Id == userId);   
        }
    }
}
