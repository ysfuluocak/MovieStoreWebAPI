using Application.Interfaces.Repositories.ActorRepository;
using Domain.Entities;
using Persistence.Context;
using Persistence.Repositories.EntityFramework.Common;

namespace Persistence.Repositories.EntityFramework.ActorRepository
{
    public class EfActorReadRepository : EfReadRepository<Actor>, IActorReadRepository
    {
        public EfActorReadRepository(MovieStoreDbContext context) : base(context)
        {
        }
    }
}
