using FlashCardApplication.Domain.Abstractions;
using FlashCardApplication.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlashCardApplication.Persistense.Repository
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly Lazy<IRepository<User>> _userRepository;
        private readonly Lazy<IRepository<Module>> _moduleRepository;
        private readonly Lazy<IRepository<FlashCard>> _flashCardRepository;
        public UnitOfWork()
        {
            _userRepository = new Lazy<IRepository<User>>(() => new UserRepository());
            _moduleRepository = new Lazy<IRepository<Module>>(() => new ModuleRepository());
            _flashCardRepository = new Lazy<IRepository<FlashCard>>(() => new FlashCardRepository());
        }
        public IRepository<FlashCard> FlashCardRepository => _flashCardRepository.Value;

        public IRepository<Module> ModuleRepository => _moduleRepository.Value;

        public IRepository<User> UserRepository => _userRepository.Value;

        public Task CreateDatabaseAsync()
        {
            throw new NotImplementedException();
        }

        public Task RemoveDatabaseAsync()
        {
            throw new NotImplementedException();
        }

        public Task SaveAllAsync()
        {
            throw new NotImplementedException();
        }
    }
}
