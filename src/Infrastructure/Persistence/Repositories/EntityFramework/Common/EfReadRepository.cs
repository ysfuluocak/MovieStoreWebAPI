using Application.Interfaces.Repositories.Common;
using Domain.Entities.Common;
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

        public IQueryable<TEntity> GetAllAsync()
        {
            return _context.Set<TEntity>();
        }

        public  IQueryable<TEntity> GetAsync(Expression<Func<TEntity, bool>> filter)
        {
            return  _context.Set<TEntity>().Where(filter);
        }

        public async Task<TEntity> GetByIdAsync(int id)
        {
            return await _context.Set<TEntity>().FindAsync(id);
        }
    }
}
