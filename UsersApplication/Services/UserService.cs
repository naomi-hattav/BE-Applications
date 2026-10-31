using UsersApplication.Domain;

namespace UsersApplication.Services
{
    public class UserService : IUserService
    {
        private readonly List<User> _users = new();  
        private int _nextId = 1;
        public bool Delete(int id)
        {
            var user = GetById(id);
            if (user == null)
            {
                return false;
            }
            _users.Remove(user);
            return true;
        }

        public IList<User> GetAll()
        {
            return _users;
        }

        public User? GetById(int id)
        {
            return _users.FirstOrDefault(x => x.Id == id);
        }

        public User Upset(User user)
        {
            var index = _users.FindIndex(x => x.Id == user.Id); 
            if(index == -1)
            {
                user.Id = _nextId++;
                _users.Add(user);
            }
            else
            {
                _users[index] = user;
            }
            return user;
        }
    }
}
