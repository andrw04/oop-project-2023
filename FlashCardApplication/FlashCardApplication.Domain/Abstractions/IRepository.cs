using FlashCardApplication.Domain.Entities;

namespace FlashCardApplication.Domain.Abstractions
{
    public interface IRepository<T> where T : Entity
    {
        Task<T?> GetByIdAsync(int id, CancellationToken cancellationToken = default);

        Task<IReadOnlyCollection<T>> GetAllAsync(CancellationToken cancellationToken = default);

        Task AddAsync(T entity);

        Task DeleteAsync(T entity, CancellationToken cancellationToken = default);
    }
}
