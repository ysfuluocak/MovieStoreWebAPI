using Application.Interfaces.Repositories.DirectorRepository;
using Domain.Entities;
using Persistence.Context;
using Persistence.Repositories.EntityFramework.Common;

namespace Persistence.Repositories.EntityFramework.DirectorRepository
{
    public class EfDirectorReadRepository : EfReadRepository<Director>, IDirectorReadRepository
    {
        public EfDirectorReadRepository(MovieStoreDbContext context) : base(context)
        {
        }
    }
}
