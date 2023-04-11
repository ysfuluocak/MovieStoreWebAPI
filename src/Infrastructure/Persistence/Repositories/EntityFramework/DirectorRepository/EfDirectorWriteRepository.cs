using Application.Interfaces.Repositories.DirectorRepository;
using Domain.Entities;
using Persistence.Context;
using Persistence.Repositories.EntityFramework.Common;

namespace Persistence.Repositories.EntityFramework.DirectorRepository
{
    public class EfDirectorWriteRepository : EfWriteRepository<Director>, IDirectorWriteRepository
    {
        public EfDirectorWriteRepository(MovieStoreDbContext context) : base(context)
        {
        }
    }
}
