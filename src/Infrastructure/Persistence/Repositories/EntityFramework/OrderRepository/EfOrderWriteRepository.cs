using Application.Interfaces.Repositories.OrderRepository;
using Domain.Entities;
using Persistence.Context;
using Persistence.Repositories.EntityFramework.Common;

namespace Persistence.Repositories.EntityFramework.OrderRepository
{
    public class EfOrderWriteRepository : EfWriteRepository<Order>, IOrderWriteRepository
    {
        public EfOrderWriteRepository(MovieStoreDbContext context) : base(context)
        {
        }
    }
}
