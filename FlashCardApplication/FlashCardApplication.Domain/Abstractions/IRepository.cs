using FlashCardApplication.Domain.Entities;
using MongoDB.Bson;
using MongoDB.Driver;

namespace FlashCardApplication.Domain.Abstractions
{
    public interface IRepository<T> where T : Entity
    {
        Task AddAsync(T entity);

        Task<T?> FindByIdAsync(Guid id);

        Task<bool> ExistsById(Guid id);
        Task<IEnumerable<T>> GetAllAsync();

        Task UpdateAsync(T entity);

        Task DeleteByIdAsync(Guid id);
    }
}
