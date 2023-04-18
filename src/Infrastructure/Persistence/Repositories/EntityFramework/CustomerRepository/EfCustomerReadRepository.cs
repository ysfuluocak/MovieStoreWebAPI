using Application.Interfaces.Repositories.CustomerRepository;
using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Persistence.Context;
using Persistence.Repositories.EntityFramework.Common;

namespace Persistence.Repositories.EntityFramework.CustomerRepository
{
    public class EfCustomerReadRepository : EfReadRepository<Customer>, ICustomerReadRepository
    {
        private readonly MovieStoreDbContext _context;
        public EfCustomerReadRepository(MovieStoreDbContext context) : base(context)
        {
            _context = context;
        }

        public async Task<Customer?> GetOrderByCustomerIdAsync(int customerId)
        {
            return await _context.Set<Customer>().Include(o=>o.Orders).ThenInclude(m=>m.Movie).FirstOrDefaultAsync(c=>c.Id==customerId);
        }
    }
}
