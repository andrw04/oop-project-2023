using Domain;

namespace Repository
{
    public class UserRepository : IRepository<User>
    {
        private List<User> users = new();

        public long Count()
        {
            return users.Count;
        }

        public void DeleteAll(IEnumerable<User> entities)
        {
            foreach(var entity in entities)
            {
                if(ExistsById(entity.Id))
                    users.Remove(entity);
            }
        }

        public void DeleteById(long id)
        {
            var user = FindById(id);
            if(user != null)
                users.Remove(user);
        }

        public bool ExistsById(long id)
        {
            var user = FindById(id);
            if(user != null)
                return true;
            else
                return false;
        }

        public User? FindById(long id)
        {
            foreach(var user in users)
            {
                if(user.Id == id)
                    return user;
            }
            return null;
        }

        public User? FindByLogin(string login)
        {
            foreach(var user in users)
            {
                if(user.Login == login)
                    return user;
            }
            return null;
        }

        public void Save(User entity)
        {
            if(FindById(entity.Id) == null)
                users.Add(entity);
        }
    }
}