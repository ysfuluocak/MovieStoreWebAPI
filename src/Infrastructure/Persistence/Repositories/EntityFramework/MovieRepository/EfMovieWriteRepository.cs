using Application.Interfaces.Repositories.MovieRepository;
using Domain.Entities;
using Persistence.Context;
using Persistence.Repositories.EntityFramework.Common;

namespace Persistence.Repositories.EntityFramework.MovieRepository
{
    public class EfMovieWriteRepository : EfWriteRepository<Movie>, IMovieWriteRepository
    {
        public EfMovieWriteRepository(MovieStoreDbContext context) : base(context)
        {
        }
    }
}
