using Application.Interfaces.Repositories.MovieRepository;
using Domain.Entities;
using Persistence.Context;
using Persistence.Repositories.EntityFramework.Common;

namespace Persistence.Repositories.EntityFramework.MovieRepository
{
    public class EfMovieReadRepository : EfReadRepository<Movie>, IMovieReadRepository
    {
        public EfMovieReadRepository(MovieStoreDbContext context) : base(context)
        {
        }
    }
}
