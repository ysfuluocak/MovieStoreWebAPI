﻿using Application.Interfaces.Repositories.Common;
using Domain.Entities;

namespace Application.Interfaces.Repositories.DirectorRepository
{
    public interface IDirectorReadRepository : IReadRepository<Director>
    {
        Task<IQueryable<Movie>> GetDirectorMoviesAsync(int id);
    }
}
