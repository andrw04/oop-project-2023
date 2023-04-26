using FlashCardApplication.Domain.Abstractions;
using FlashCardApplication.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace FlashCardApplication.Persistense.Repository
{
    public class UserRepository : IRepository<User>
    {
        public Task AddAsync(User entity, CancellationToken cancellationToken = default)
        {
            throw new NotImplementedException();
        }

        public Task DeleteAsync(User entity, CancellationToken cancellationToken = default)
        {
            throw new NotImplementedException();
        }

        public Task<User> FirstOrDefaultAsync(Expression<Func<User, bool>> filter, CancellationToken cancellationToken = default)
        {
            throw new NotImplementedException();
        }

        public Task<User> GetByIdAsync(int id, CancellationToken cencellationToken = default, params Expression<Func<User, object>>[] includesProperties)
        {
            throw new NotImplementedException();
        }

        public Task<IReadOnlyList<User>> ListAllAsync(CancellationToken cancellationToken = default)
        {
            throw new NotImplementedException();
        }

        public Task<IReadOnlyList<User>> ListAsync(Expression<Func<User, bool>> filter, CancellationToken cancellationToken = default, params Expression<Func<User, object>>[]? includesProperties)
        {
            throw new NotImplementedException();
        }

        public Task UpdateAsync(User entity, CancellationToken cancellationToken = default)
        {
            throw new NotImplementedException();
        }
    }
}
