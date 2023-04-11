using Application.Interfaces.Repositories.GenreRepository;
using Domain.Entities;
using Persistence.Context;
using Persistence.Repositories.EntityFramework.Common;

namespace Persistence.Repositories.EntityFramework.GenreRepository
{
    public class EfGenreReadRepository : EfReadRepository<Genre>, IGenreReadRepository
    {
        public EfGenreReadRepository(MovieStoreDbContext context) : base(context)
        {
        }
    }
}
