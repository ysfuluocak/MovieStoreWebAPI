using Application.Interfaces.Repositories.Common;
using Domain.Entities;

namespace Application.Interfaces.Repositories.OrderRepository
{
    public interface IOrderReadRepository : IReadRepository<Order>
    {
    }
}
