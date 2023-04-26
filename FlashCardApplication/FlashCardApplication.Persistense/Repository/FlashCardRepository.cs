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
    public class FlashCardRepository : IRepository<FlashCard>
    {
        public Task AddAsync(FlashCard entity, CancellationToken cancellationToken = default)
        {
            throw new NotImplementedException();
        }

        public Task DeleteAsync(FlashCard entity, CancellationToken cancellationToken = default)
        {
            throw new NotImplementedException();
        }

        public Task<FlashCard> FirstOrDefaultAsync(Expression<Func<FlashCard, bool>> filter, CancellationToken cancellationToken = default)
        {
            throw new NotImplementedException();
        }

        public Task<FlashCard> GetByIdAsync(int id, CancellationToken cencellationToken = default, params Expression<Func<FlashCard, object>>[] includesProperties)
        {
            throw new NotImplementedException();
        }

        public Task<IReadOnlyList<FlashCard>> ListAllAsync(CancellationToken cancellationToken = default)
        {
            throw new NotImplementedException();
        }

        public Task<IReadOnlyList<FlashCard>> ListAsync(Expression<Func<FlashCard, bool>> filter, CancellationToken cancellationToken = default, params Expression<Func<FlashCard, object>>[]? includesProperties)
        {
            throw new NotImplementedException();
        }

        public Task UpdateAsync(FlashCard entity, CancellationToken cancellationToken = default)
        {
            throw new NotImplementedException();
        }
    }
}
