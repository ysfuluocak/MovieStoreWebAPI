using Application.Dtos;
using Application.Interfaces.Repositories.UserRepository;
using Domain.Entities;
using Persistence.Context;
using Persistence.Repositories.EntityFramework.Common;

namespace Persistence.Repositories.EntityFramework.UserRepository
{
    public class EfUserWriteRepository : EfWriteRepository<User>, IUserWriteRepository
    {
        private readonly MovieStoreDbContext _context;
        public EfUserWriteRepository(MovieStoreDbContext context) : base(context)
        {
            _context = context;
        }

        public void UpdateRefreshToken(User user, AccessToken token)
        {
            user.RefreshToken = token.RefreshToken;
            user.RefreshTokenExpireDate = token.Expiration.AddMinutes(5);           
        }
    }
}
