using Domain;

namespace Repository
{
    public class Repository : IRepository
    {
        public Entity? FindById(long id)
        {
            foreach(var item in storage)
            {
                if(item.Id == id)
                {
                    return item;
                }
            }
            return null;
        }
        public bool ExistsById(long id)
        {
            var item = FindById(id);
            if(item == null)
                return false;
            else
                return true;
        }
        public long Count()
        {
            return storage.Count;
        }
        public void DeleteById(long id)
        {
            var item = FindById(id);
            if(item != null)
                storage.Remove(item);
        }
        public void DeleteAll(IEnumerable<Entity> entities)
        {
            foreach(var item in entities)
            {
                if(ExistsById(item.Id))
                    storage.Remove(item);
            }
        }
        public void Save(Entity entity)
        {
            if(!ExistsById(entity.Id))
                storage.Add(entity);
        }

        public IEnumerable<Entity> GetAll()
        {
            return storage;
        }
        protected List<Entity> storage = new();
    }
}