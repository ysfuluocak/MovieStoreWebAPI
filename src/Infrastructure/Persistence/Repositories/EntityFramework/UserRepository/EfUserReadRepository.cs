using Application.Interfaces.Repositories.UserRepository;
using Domain.Entities;
using Persistence.Context;
using Persistence.Repositories.EntityFramework.Common;

namespace Persistence.Repositories.EntityFramework.UserRepository
{
    public class EfUserReadRepository : EfReadRepository<User>, IUserReadRepository
    {
        public EfUserReadRepository(MovieStoreDbContext context) : base(context)
        {
        }
    }
}
