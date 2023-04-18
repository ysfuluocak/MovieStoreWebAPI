using Application.Interfaces.Repositories.DirectorRepository;
using MediatR;

namespace Application.Features.CQRS.Queries.GetDirectorMoviesQuery
{
    public class GetDirectorMoviesQueryHandler : IRequestHandler<GetDirectorMoviesQueryRequest, List<GetDirectorMoviesQueryResponse>>
    {
        private readonly IDirectorReadRepository _directorReadRepository;

        public GetDirectorMoviesQueryHandler(IDirectorReadRepository directorReadRepository)
        {
            _directorReadRepository = directorReadRepository;
        }

        public async Task<List<GetDirectorMoviesQueryResponse>> Handle(GetDirectorMoviesQueryRequest request, CancellationToken cancellationToken)
        {
            var movies = await _directorReadRepository.GetDirectorMoviesAsync(request.Id);
            var response = new List<GetDirectorMoviesQueryResponse>();
            foreach (var movie in movies)
            {
                response.Add(new GetDirectorMoviesQueryResponse { MovieName = movie.Name,MovieDate=movie.MovieDate,Genre=movie.Genre.Title,DirectorFullName=movie.Director.FirstName+" "+movie.Director.LastName});
            }
            return response;
        }
    }
}
