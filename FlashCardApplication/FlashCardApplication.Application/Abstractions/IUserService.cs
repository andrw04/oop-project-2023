using FlashCardApplication.Domain.Entities;

namespace FlashCardApplication.Application.Abstractions
{
    public interface IUserService : IBaseService<User>
    {
        Task<User?> GetUserAsync(string login, string password);

        Task EditProfileAsync(User user);
    }
}
