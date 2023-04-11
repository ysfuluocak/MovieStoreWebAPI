using Domain.Entities.Common;

namespace Application.Interfaces.Repositories.Common
{
    public interface IEntityRepository<T> where T : BaseEntity, new()
    {

    }
}
