using Application.Interfaces.Repositories.OrderRepository;
using Domain.Entities;
using Persistence.Context;
using Persistence.Repositories.EntityFramework.Common;

namespace Persistence.Repositories.EntityFramework.OrderRepository
{
    public class EfOrderReadRepository : EfReadRepository<Order>, IOrderReadRepository
    {
        public EfOrderReadRepository(MovieStoreDbContext context) : base(context)
        {
        }
    }
}
