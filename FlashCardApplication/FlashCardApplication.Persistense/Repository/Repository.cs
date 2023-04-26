using FlashCardApplication.Domain.Abstractions;
using FlashCardApplication.Domain.Entities;
using FlashCardApplication.Persistense.Data;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace FlashCardApplication.Persistense.Repository
{
    public class Repository<T> : IRepository<T> where T : Entity
    {
        private readonly AppDbContext _context;
        private readonly DbSet<T> _entities;

        public Repository(AppDbContext context)
        {
            _context = context;
            _entities = context.Set<T>();
        }
        public async Task AddAsync(T entity, CancellationToken cancellationToken = default)
        {
            await _context.AddAsync(entity, cancellationToken);
        }

        public async Task DeleteAsync(T entity, CancellationToken cancellationToken = default)
        {
            await Task.Run(() =>
            {
                var item = _context.Remove(entity);
            });
        }

        public async Task<T> FirstOrDefaultAsync(Expression<Func<T, bool>> filter, CancellationToken cancellationToken = default)
        {
            return await _entities.FirstOrDefaultAsync(filter, cancellationToken);
        }

        public async Task<T> GetByIdAsync(int id, CancellationToken cencellationToken = default)
        {
            IQueryable<T>? query = _entities.AsQueryable();
            return await query.FirstAsync((itm) => itm.Id == id);
        }

        public async Task<IReadOnlyList<T>> ListAllAsync(CancellationToken cancellationToken = default)
        {
            IQueryable<T>? query = _entities.AsQueryable();
            return await query.ToListAsync();
        }

        public async Task<IReadOnlyList<T>> ListAsync(Expression<Func<T, bool>> filter, CancellationToken cancellationToken = default)
        {
            IQueryable<T>? query = _entities.AsQueryable();
            if (filter != null)
            {
                query = query.Where(filter);
            }

            return await query.ToListAsync();
        }

        public Task UpdateAsync(T entity, CancellationToken cancellationToken = default)
        {
            _context.Entry(entity).State = EntityState.Modified;
            return Task.CompletedTask;
        }
    }
}
