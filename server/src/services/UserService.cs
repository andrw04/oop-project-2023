using Domain;
using Repository;

namespace Services
{
    public class UserService
    {
        public UserService(IUserRepository repository)
        {
            userRepository = repository;
        }
        public void Register(string login, string password, string email)
        {
            userRepository.Save(new User(login, password, email));
        }
        public User? Login(string login, string password)
        {
            var user = userRepository.FindByLogin(login);
            if(user != null && user.Password == password)
                return user;
            return null;
        }
        public void EditProfile(string login, string? email=null,string? name=null, string? photo=null)
        {
            var user = userRepository.FindByLogin(login);
            if(user != null)
            {
                user.Email = email ?? user.Email;
                user.Name = name ?? user.Name;
                user.Photo = photo ?? user.Email;
            }
        }
        public void RemoveUser(string login)
        {
            var user = userRepository.FindByLogin(login);
            if(user != null)
                userRepository.DeleteById(user.Id);
        }
        private IUserRepository userRepository;
    }
}