using Application.Interfaces.Repositories.ActorRepository;
using Domain.Entities;
using Persistence.Context;
using Persistence.Repositories.EntityFramework.Common;

namespace Persistence.Repositories.EntityFramework.ActorRepository
{
    public class EfActorWriteRepository : EfWriteRepository<Actor>, IActorWriteRepository
    {
        public EfActorWriteRepository(MovieStoreDbContext context) : base(context)
        {
        }
    }
}
