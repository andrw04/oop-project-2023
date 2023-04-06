using Domain;
using Repository;

namespace Services
{
    public class UserService
    {
        public UserService(UserRepository repository)
        {
            userRepository = repository;
        }
        public void Register(string login, string password, string email)
        {
            userRepository.Save(new User(login, password, email));
            Login(login,password);
        }
        public void Login(string login, string password)
        {
            var user = userRepository.FindByLogin(login);
            if(user != null && user.Password == password)
                activeUser = user;
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
        private UserRepository userRepository;
        private User? activeUser = null;
    }
}