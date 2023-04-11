using Application.Interfaces.Repositories.Common;
using Domain.Entities.Common;
using Microsoft.EntityFrameworkCore;
using Persistence.Context;

namespace Persistence.Repositories.EntityFramework.Common
{
    public class EfWriteRepository<TEntity> : IWriteRepository<TEntity> where TEntity : BaseEntity, new()
    {
        private readonly MovieStoreDbContext _context;

        public EfWriteRepository(MovieStoreDbContext context)
        {
            _context = context;
        }

        public async Task AddAsync(TEntity entity)
        {
            await _context.AddAsync(entity);
        }

        public void Update(TEntity entity)
        {
            _context.Entry(entity).State = EntityState.Modified;
        }

        public void Delete(TEntity entity)
        {
            _context.Entry(entity).State = EntityState.Deleted;
        }

        public async Task SaveAsync()
        {
            await _context.SaveChangesAsync();
        }
    }
}
