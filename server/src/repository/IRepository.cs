using Domain;

namespace Repository
{
    public interface IRepository<Type>
    {
        Type? FindById(long id);
        bool ExistsById(long id);
        long Count();
        void DeleteById(long id);
        void DeleteAll(IEnumerable<Type> entities);
        void Save(Type entity);
    }

    public interface IUserRepository : IRepository<User>
    {

    }

    public interface IModuleRepository : IRepository<Module>
    {

    }

    public interface IFlashCardRepository : IRepository<IFlashCard>
    {

    }
}