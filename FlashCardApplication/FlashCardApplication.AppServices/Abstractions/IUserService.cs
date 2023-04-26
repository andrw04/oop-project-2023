using FlashCardApplication.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlashCardApplication.AppServices.Abstractions
{
    public interface IUserService : IBaseService<User>
    {
        Task Registrate(User user);
        Task<User?> Login(string login, string password);
        Task ChangeUser(User user);
    }
}
