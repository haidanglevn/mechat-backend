using Core.Entities;

namespace WebAPI.Repositories.Interfaces
{
    public interface IUserRepo
    {
        IEnumerable<User> GetAllUsers(GetAllParams options);
        User? GetOneUser(Guid userId);
        User CreateNewUser(User user);
        bool CheckEmail(string email);
    }
}
