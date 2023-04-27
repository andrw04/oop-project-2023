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
        private readonly Lazy<IRepository<DoublePageFlashCard>> _dpFlashCardRepository;
        private readonly Lazy<IRepository<SinglePageFlashCard>> _spFlashCardRepository;

        public UnitOfWork(AppDbContext context)
        {
            _context = context;
            _userRepository = new Lazy<IRepository<User>>(() => new Repository<User>(context));
            _moduleRepository = new Lazy<IRepository<Module>>(() => new Repository<Module>(context));
            _dpFlashCardRepository = new Lazy<IRepository<DoublePageFlashCard>>(() => new Repository<DoublePageFlashCard>(context));
            _spFlashCardRepository = new Lazy<IRepository<SinglePageFlashCard>>(()=> new Repository<SinglePageFlashCard>(context));
        }

        public IRepository<SinglePageFlashCard> SinglePageFlashCardRepository => _spFlashCardRepository.Value;

        public IRepository<DoublePageFlashCard> DoublePageFlashCardRepository => _dpFlashCardRepository.Value;

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
