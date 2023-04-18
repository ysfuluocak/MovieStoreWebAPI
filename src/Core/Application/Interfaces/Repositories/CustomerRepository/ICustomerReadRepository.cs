using Application.Interfaces.Repositories.Common;
using Domain.Entities;

namespace Application.Interfaces.Repositories.CustomerRepository
{
    public interface ICustomerReadRepository : IReadRepository<Customer>
    {
       Task<Customer?> GetOrderByCustomerIdAsync(int customerId);
    }
}
