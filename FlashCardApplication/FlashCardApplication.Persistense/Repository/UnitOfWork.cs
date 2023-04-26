﻿using FlashCardApplication.Domain.Abstractions;
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
        private readonly AppDbContext _context;
        private readonly Lazy<IRepository<User>> _userRepository = new Lazy<IRepository<User>>(new UserRepository());
        private readonly Lazy<IRepository<FlashCard>> _flashCardRepository 
            = new Lazy<IRepository<FlashCard>>(new FlashCardRepository());

        public IRepository<FlashCard> FlashCardRepository => throw new NotImplementedException();

        public IRepository<Module> ModuleRepository => throw new NotImplementedException();

        public IRepository<User> UserRepository => throw new NotImplementedException();

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
