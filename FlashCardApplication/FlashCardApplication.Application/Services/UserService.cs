using FlashCardApplication.MyApplication.Abstractions;
using FlashCardApplication.Domain.Abstractions;
using FlashCardApplication.Domain.Entities;
using FlashCardApplication.Persistense.Repository;

namespace FlashCardApplication.MyApplication.Services
{
    public class UserService : IUserService
    {
        IRepository<User> userRepository;
        public UserService()
        {
            userRepository = new Repository<User>("Users");
        }
        public async Task AddAsync(User entity)
        {
            await userRepository.AddAsync(entity);
        }

        public async Task DeleteAsync(Guid id)
        {
            await userRepository.DeleteByIdAsync(id);
        }

        public async Task EditProfileAsync(User user)
        {
            await userRepository.UpdateAsync(user);
        }

        public async Task<IEnumerable<User>> GetAllAsync()
        {
            return await userRepository.GetAllAsync();
        }

        public async Task<User?> GetByIdAsync(Guid id)
        {
            return await userRepository.FindByIdAsync(id);
        }

        public async Task<User?> GetUserAsync(string login, string password)
        {
            var users = await userRepository.GetAllAsync();

            return users.FirstOrDefault((x) => x.Login == login && x.Password == password);
        }

        public async Task UpdateAsync(User entity)
        {
            await userRepository.UpdateAsync(entity);
        }
    }
}
