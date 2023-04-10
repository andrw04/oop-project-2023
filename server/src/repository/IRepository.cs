using Domain;

namespace Repository
{
    public interface IRepository
    {
        public Entity? FindById(long id);
        public bool ExistsById(long id);
        public long Count();
        public void DeleteById(long id);
        public void DeleteAll(IEnumerable<Entity> entities);
        public void Save(Entity entity);
        public IEnumerable<Entity> GetAll();
    }   
}