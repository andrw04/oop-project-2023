using FlashCardApplication.Domain.Abstractions;
using FlashCardApplication.Domain.Entities;
using FlashCardApplication.Persistense.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlashCardApplication.Persistense.Repository
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly AppDbContext _context;
        private readonly Lazy<IRepository<User>> _userRepository;
        private readonly Lazy<IRepository<Module>> _moduleRepository;
        private readonly Lazy<IRepository<FlashCard>> _flashCardRepository;

        public UnitOfWork(AppDbContext context)
        {
            _context = context;
            _userRepository = new Lazy<IRepository<User>>(() => new Repository<User>(context));
            _moduleRepository = new Lazy<IRepository<Module>>(() => new Repository<Module>(context));
            _flashCardRepository = new Lazy<IRepository<FlashCard>>(() => new Repository<FlashCard>(context));
        }

        public IRepository<FlashCard> FlashCardRepository => _flashCardRepository.Value;

        public IRepository<Module> ModuleRepository => _moduleRepository.Value;

        public IRepository<User> UserRepository => _userRepository.Value;

        public async Task CreateDatabaseAsync()
        {
            await _context.Database.EnsureCreatedAsync();
        }

        public async Task RemoveDatabaseAsync()
        {
            await _context.Database.EnsureDeletedAsync();
        }

        public async Task SaveAllAsync()
        {
            await _context.SaveChangesAsync();
        }
    }
}
