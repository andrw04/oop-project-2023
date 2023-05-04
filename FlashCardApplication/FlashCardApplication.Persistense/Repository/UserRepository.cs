using FlashCardApplication.Domain.Abstractions;
using FlashCardApplication.Domain.Entities;

namespace FlashCardApplication.Persistense.Repository
{
    public class UserRepository : IRepository<User>
    {
        private List<User> users = new List<User>();
        public async Task AddAsync(User entity)
        {
            await Task.Run(() =>
            {
                users.Add(entity);
            });
        }

        public async Task DeleteAsync(User entity, CancellationToken cancellationToken = default)
        {
            await Task.Run(() =>
            {
                users.Remove(entity);
            });
        }

        public async Task<IReadOnlyCollection<User>> GetAllAsync(CancellationToken cancellationToken = default)
        {
            var result = await Task.Run(() => users);
            return result;
        }

        public Task<User?> GetByIdAsync(int id, CancellationToken cancellationToken = default)
        {
            return Task.Run(() => users.FirstOrDefault((item) => item?.Id == id, null));
        }
    }
}
