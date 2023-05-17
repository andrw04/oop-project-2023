using FlashCardApplication.Domain.Entities;

namespace FlashCardApplication.MyApplication.Abstractions
{
    public interface IUserService : IBaseService<User>
    {
        Task<User?> GetUserAsync(string login, string password);

        Task EditProfileAsync(User user);
    }
}
