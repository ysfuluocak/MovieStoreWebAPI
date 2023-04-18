using Application.Interfaces.Repositories.Common;
using Domain.Entities;

namespace Application.Interfaces.Repositories.UserRepository
{
    public interface IUserReadRepository : IReadRepository<User>
    {
    }
}
