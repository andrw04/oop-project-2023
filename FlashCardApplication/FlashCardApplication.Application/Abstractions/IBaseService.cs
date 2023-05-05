using FlashCardApplication.Domain.Entities;

namespace FlashCardApplication.Application.Abstractions
{
    public interface IBaseService<T> where T : Entity
    {
        Task<IEnumerable<T>> GetAllAsync();

        Task<T?> GetByIdAsync(Guid id);

        Task AddAsync(T entity);

        Task UpdateAsync(T entity);

        Task DeleteAsync(Guid id);
    }
}
