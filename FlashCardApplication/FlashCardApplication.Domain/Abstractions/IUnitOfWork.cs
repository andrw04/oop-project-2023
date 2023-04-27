using FlashCardApplication.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlashCardApplication.Domain.Abstractions
{
    public interface IUnitOfWork
    {
        IRepository<SinglePageFlashCard> SinglePageFlashCardRepository { get; }
        IRepository<DoublePageFlashCard> DoublePageFlashCardRepository { get; }
        IRepository<Module> ModuleRepository { get; }
        IRepository<User> UserRepository { get; }
        public Task RemoveDatabaseAsync();
        public Task CreateDatabaseAsync();
        public Task SaveAllAsync();
    }
}
