using Application.Interfaces.Repositories.Common;
using Domain.Entities.Common;
using Microsoft.EntityFrameworkCore;
using Persistence.Context;
using System.Linq.Expressions;

namespace Persistence.Repositories.EntityFramework.Common
{
    public class EfReadRepository<TEntity> : IReadRepository<TEntity> where TEntity : BaseEntity, new()
    {
        private readonly MovieStoreDbContext _context;

        public EfReadRepository(MovieStoreDbContext context)
        {
            _context = context;
        }

        public IQueryable<TEntity> GetAll()
        {
            return _context.Set<TEntity>();
        }

        public async Task<TEntity?> GetAsync(Expression<Func<TEntity, bool>> filter)
        {
            return await _context.Set<TEntity>().FirstOrDefaultAsync(filter);
        }

        public  IQueryable<TEntity> GetByFilter(Expression<Func<TEntity, bool>> filter)
        {
            return  _context.Set<TEntity>().Where(filter);
        }

        public async Task<TEntity?> GetByIdAsync(int id)
        {
            return await _context.Set<TEntity>().FindAsync(id);
        }
    }
}
