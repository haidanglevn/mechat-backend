using Core.Entities;

namespace Core.Interfaces
{
    public interface IUserRepo
    {
        IEnumerable<User> GetAllUsers(GetAllParams options);
        User? GetOneUser(Guid userId);
        User CreateNewUser(User user);
        User? FindByEmail(string email);
        bool CheckEmail(string email);
        bool CheckUserExist(Guid userId);
        bool UpdateUser(Guid userId, User user);
        bool DeleteUser(Guid userId);
    }
}
