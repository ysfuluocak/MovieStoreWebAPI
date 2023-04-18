using Application.Dtos;
using Application.Interfaces.Repositories.Common;
using Domain.Entities;

namespace Application.Interfaces.Repositories.UserRepository
{
    public interface IUserWriteRepository : IWriteRepository<User>
    {
        void UpdateRefreshToken(User user, AccessToken token);
    }
}
