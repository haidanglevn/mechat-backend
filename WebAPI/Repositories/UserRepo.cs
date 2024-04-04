using Core.Entities;
using Core.Interfaces;
using Microsoft.EntityFrameworkCore;
using WebAPI.Database;

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
        public User? FindByEmail(string email)
        {
            return _users.AsNoTracking().FirstOrDefault(u => u.Email == email);
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
            return _users.FirstOrDefault(u => u.Id == userId);
        }

        public bool CheckUserExist(Guid userId)
        {
            return _users.Any(c => c.Id == userId);
        }

        public int GetHighestTagForUsername(string username)
        {
            var highestTag = _users
                             .Where(u => u.UserName == username)
                             .Select(u => u.Tag)
                             .ToList()
                             .Select(tag => int.Parse(tag.TrimStart('#')))
                             .DefaultIfEmpty(0)
                             .Max();

            return highestTag;
        }

    }
};
