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
        }
        public User? Login(string login, string password)
        {
            var user = userRepository.FindByLogin(login);
            if(user != null && user.Password == password)
                return user;
            else
                return null;
        }
        public bool EditProfile(User user)
        {
            var oldInfoUser = userRepository.FindById(user.Id);
            if(oldInfoUser != null)
            {
                var usr = (User)oldInfoUser;
                usr.Email = user.Email;
                usr.Name = user.Name;
                usr.Photo = user.Photo;
                return true;
            }
            return false;
        }
        public bool RemoveUser(User user)
        {
            var userForDelete = userRepository.FindById(user.Id);
            if(userForDelete != null)
            {
                var usr = (User)userForDelete;
                userRepository.DeleteById(usr.Id);
                return true;
            }
            return false;
        }
        private UserRepository userRepository;
    }
}