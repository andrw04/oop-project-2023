using Domain;
using Repository;

namespace Services
{
    public class UserService
    {
        public UserService(IRepository<User,string> repository)
        {
            userRepository = repository;
        }
        private IRepository<User,string> userRepository;

        public void Register(string login, string password, string email)
        {
            userRepository.Save(new User(login, password, email));
        }
        public User? Login(string login, string password)
        {
            var user = userRepository.FindById(login);
            if(user != null && user.Password == password)
                return user;
            return null;
        }

        public void EditProfile(string login, string? email=null,string? name=null, string? photo=null)
        {
            var user = userRepository.FindById(login);
            if(user != null)
            {
                user.Email = email ?? user.Email;
                user.Name = name ?? user.Name;
                user.Photo = photo ?? user.Email;
            }
        }
        public void RemoveUser(string login)
        {
            userRepository.DeleteById(login);
        }
    }
}