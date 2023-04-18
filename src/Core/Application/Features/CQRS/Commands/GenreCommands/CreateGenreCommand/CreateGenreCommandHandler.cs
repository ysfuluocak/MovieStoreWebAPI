using Application.Interfaces.Repositories.GenreRepository;
using Domain.Entities;
using MediatR;

namespace Application.Features.CQRS.Commands.GenreCommands.CreateGenreCommand
{
    public class CreateGenreCommandHandler : IRequestHandler<CreateGenreCommandRequest, CreateGenreCommandResponse>
    {
        private readonly IGenreWriteRepository _genreWriteRepository;

        public CreateGenreCommandHandler(IGenreWriteRepository genreWriteRepository)
        {
            _genreWriteRepository = genreWriteRepository;
        }

        public async Task<CreateGenreCommandResponse> Handle(CreateGenreCommandRequest request, CancellationToken cancellationToken)
        {
            var genre = new Genre()
            {
                Title = request.Title,
            };
            await _genreWriteRepository.AddAsync(genre);
            await _genreWriteRepository.SaveAsync();
            return new();
        }
    }
}
