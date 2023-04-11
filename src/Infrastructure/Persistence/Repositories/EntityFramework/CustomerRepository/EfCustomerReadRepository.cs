using Application.Interfaces.Repositories.CustomerRepository;
using Domain.Entities;
using Persistence.Context;
using Persistence.Repositories.EntityFramework.Common;

namespace Persistence.Repositories.EntityFramework.CustomerRepository
{
    public class EfCustomerReadRepository : EfReadRepository<Customer>, ICustomerReadRepository
    {
        public EfCustomerReadRepository(MovieStoreDbContext context) : base(context)
        {
        }
    }
}
