using Domain;

namespace Repository
{
    public class UserRepository : Repository
    {
        public User? FindByLogin(string login)
        {
            foreach(var item in storage)
            {
                var user = (User)item;
                if(user.Login == login)
                {
                    return user;
                }
            }
            return null;
        }
    }
}