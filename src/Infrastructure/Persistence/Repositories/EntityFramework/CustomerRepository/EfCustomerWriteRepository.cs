using Application.Interfaces.Repositories.CustomerRepository;
using Domain.Entities;
using Persistence.Context;
using Persistence.Repositories.EntityFramework.Common;

namespace Persistence.Repositories.EntityFramework.CustomerRepository
{
    public class EfCustomerWriteRepository : EfWriteRepository<Customer>, ICustomerWriteRepository
    {
        public EfCustomerWriteRepository(MovieStoreDbContext context) : base(context)
        {
        }
    }
}
