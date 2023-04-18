using Domain.Entities.Common;
using System.Linq.Expressions;

namespace Application.Interfaces.Repositories.Common
{
    public interface IReadRepository<T> : IEntityRepository<T> where T : BaseEntity, new()
    {
        IQueryable<T> GetAll();
        IQueryable<T> GetByFilter(Expression<Func<T, bool>> filter);
        Task<T?> GetAsync(Expression<Func<T, bool>> filter);
        Task<T?> GetByIdAsync(int id);

    }
}
