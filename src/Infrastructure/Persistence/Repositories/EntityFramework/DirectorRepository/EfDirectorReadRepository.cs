using Application.Interfaces.Repositories.DirectorRepository;
using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Persistence.Context;
using Persistence.Repositories.EntityFramework.Common;

namespace Persistence.Repositories.EntityFramework.DirectorRepository
{
    public class EfDirectorReadRepository : EfReadRepository<Director>, IDirectorReadRepository
    {
        readonly MovieStoreDbContext _context;
        public EfDirectorReadRepository(MovieStoreDbContext context) : base(context)
        {
            _context = context;
        }

        public async Task<IQueryable<Movie>> GetDirectorMoviesAsync(int id)
        {
            var director = await _context.Set<Director>().Include(d => d.Movies).ThenInclude(g=>g.Genre).FirstOrDefaultAsync(d => d.Id == id);
            return director.Movies.AsQueryable();
        }

    }
}
