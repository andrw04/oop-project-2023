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
    public class ModuleRepository : IRepository<Module>
    {
        public Task AddAsync(Module entity, CancellationToken cancellationToken = default)
        {
            throw new NotImplementedException();
        }

        public Task DeleteAsync(Module entity, CancellationToken cancellationToken = default)
        {
            throw new NotImplementedException();
        }

        public Task<Module> FirstOrDefaultAsync(Expression<Func<Module, bool>> filter, CancellationToken cancellationToken = default)
        {
            throw new NotImplementedException();
        }

        public Task<Module> GetByIdAsync(int id, CancellationToken cencellationToken = default, params Expression<Func<Module, object>>[] includesProperties)
        {
            throw new NotImplementedException();
        }

        public Task<IReadOnlyList<Module>> ListAllAsync(CancellationToken cancellationToken = default)
        {
            throw new NotImplementedException();
        }

        public Task<IReadOnlyList<Module>> ListAsync(Expression<Func<Module, bool>> filter, CancellationToken cancellationToken = default, params Expression<Func<Module, object>>[]? includesProperties)
        {
            throw new NotImplementedException();
        }

        public Task UpdateAsync(Module entity, CancellationToken cancellationToken = default)
        {
            throw new NotImplementedException();
        }
    }
}
