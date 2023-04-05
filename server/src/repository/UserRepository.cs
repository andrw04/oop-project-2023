using Domain;

namespace Repository
{
    public class UserRepository : IRepository<User, string>
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
                if(ExistsById(entity.Login))
                    users.Remove(entity);
            }
        }

        public void DeleteById(string id)
        {
            var user = FindById(id);
            if(user != null)
                users.Remove(user);
        }

        public bool ExistsById(string id)
        {
            foreach(var user in users)
            {
                if(user.Login == id)
                    return true;
            }
            return false;
        }

        public IEnumerable<User> FindAll()
        {
            return users;
        }

        public User? FindById(string id)
        {
            foreach(var user in users)
            {
                if(user.Login == id)
                    users.Remove(user);
            }
            return null;
        }

        public void Save(User entity)
        {
            if(FindById(entity.Login) == null)
                users.Add(entity);
        }
    }
}