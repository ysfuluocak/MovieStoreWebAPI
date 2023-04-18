using Application.Interfaces.Repositories.ActorRepository;
using Application.Interfaces.Repositories.MovieRepository;
using Domain.Entities;
using MediatR;

namespace Application.Features.CQRS.Commands.MovieCommands.CreateMovieCommand
{
    public class CreateMovieCommandHandler : IRequestHandler<CreateMovieCommandRequest, CreateMovieCommandResponse>
    {
        private readonly IMovieWriteRepository _movieWriteRepository;
        private readonly IActorReadRepository _actorReadRepository;

        public CreateMovieCommandHandler(IMovieWriteRepository movieWriteRepository, IActorReadRepository actorReadRepository)
        {
            _movieWriteRepository = movieWriteRepository;
            _actorReadRepository = actorReadRepository;
        }

        public async Task<CreateMovieCommandResponse> Handle(CreateMovieCommandRequest request, CancellationToken cancellationToken)
        {
            var actor = new List<Actor>();
            foreach (var actorId in request.Actors)
            {
                actor.Add(await _actorReadRepository.GetByIdAsync(actorId));
            }
            var movie = new Movie()
            {
                Name = request.Name,
                GenreId = request.GenreId,
                DirectorId = request.DirectorId,
                Price = request.Price,
                MovieDate = request.MovieDate,
                Actors = actor
            };
            await _movieWriteRepository.AddAsync(movie);
            await _movieWriteRepository.SaveAsync();

            return new();
        }
    }
}
