using UsersApplication.Domain;

namespace UsersApplication.Services
{
    public interface IUserService
    {
        IList<User> GetAll();
        User? GetById(int id);
        User Upset(User user);
        bool Delete(int id);
    }
}
