namespace Repository
{
    public interface IRepository<Type, KeyType>
    {
        Type? FindById(KeyType id);
        IEnumerable<Type> FindAll();
        bool ExistsById(KeyType id);
        long Count();
        void DeleteById(KeyType id);
        void DeleteAll(IEnumerable<Type> entities);
        void Save(Type entity);
    }
}