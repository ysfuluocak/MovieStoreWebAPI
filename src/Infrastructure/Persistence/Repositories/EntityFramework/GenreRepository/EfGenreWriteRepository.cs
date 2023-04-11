using Application.Interfaces.Repositories.GenreRepository;
using Domain.Entities;
using Persistence.Context;
using Persistence.Repositories.EntityFramework.Common;

namespace Persistence.Repositories.EntityFramework.GenreRepository
{
    public class EfGenreWriteRepository : EfWriteRepository<Genre>, IGenreWriteRepository
    {
        public EfGenreWriteRepository(MovieStoreDbContext context) : base(context)
        {
        }
    }
}
