using Domain.Entities.Common;

namespace Application.Interfaces.Repositories.Common
{
    public interface IWriteRepository<T> : IEntityRepository<T> where T : BaseEntity, new()
    {
        Task AddAsync(T entity);
        void Update(T entity);
        void Delete(T entity);
        Task SaveAsync();
    }
}
