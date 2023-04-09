using Domain;
using Repository;
using Events;

namespace Services
{
    public class UserService
    {
        public UserService(EventManager manager)
        {
            userRepository = new UserRepository();
            this.eventManager = manager;
        }
        public void Register(User user)
        {
            userRepository.Save(user);
            eventManager.Notify($"{DateTime.Now} User id:{user.Id} has been registered.");
        }
        public User? Login(string login, string password)
        {
            var user = userRepository.FindByLogin(login);
            if (user != null && user.Password == password)
            {
                eventManager.Notify($"{DateTime.Now} User id:{user.Id} has been logged.");
                return user;
            }

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
                eventManager.Notify($"{DateTime.Now} User id:{usr.Id} has been edited.");
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
                eventManager.Notify($"{DateTime.Now} User id:{usr.Id} has been deleted.");
                return true;
            }
            return false;
        }
        private UserRepository userRepository;
        private EventManager eventManager;
    }
}